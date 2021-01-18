using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdosHealthPortraitsystemServer.Utility;
using System.Net;
using System.IO;
using OrdosHealthPortraitsystemServer.Model;
using System.Web.Script.Serialization;

namespace OrdosHealthPortraitsystemServer.Bll
{
    public class DealHttpRequestBll
    {
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        private string GetToken()
        {
            try
            {
                string result = "";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(AppConfig.m_getTokenUrl);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //获取内容
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
                //LogUtility.Debug("DealHttpRequestBll|GetToken", result);
                return result;
            }
            catch (Exception ex)
            {
                //LogUtility.Error("DealHttpRequestBll|GetToken", ex.Message);
                return "";
            }
        }

        /// <summary>
        /// 获取唯一标识
        /// </summary>
        /// <returns></returns>
        public string GetPid(string token, string idCard, string passWord)
        {
            try
            {
                RequestInfoPid requestInfo = new RequestInfoPid();
                requestInfo.accessType = "2";
                requestInfo.idCard = idCard;
                requestInfo.cardType = "01";
                requestInfo.passWord = passWord;
                requestInfo.medicalOrgId = "150600";
                requestInfo.deptId = "120";
                requestInfo.jobNo = "00012";
                string json_data = ObjectToJson.GetObjectToString(requestInfo);

                string result = "";

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(AppConfig.m_getPid);

                //LogUtility.Debug("DealHttpRequestBll|json_data", json_data);

                req.Method = "POST";

                req.ContentType = "application/json";

                //添加token
                req.Headers.Add("Api-Token", token);

                byte[] data = Encoding.UTF8.GetBytes(json_data);

                req.ContentLength = data.Length;

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);

                    reqStream.Close();
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream stream = resp.GetResponseStream();

                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                //LogUtility.Debug("DealHttpRequestBll|GetPid2", result);
                return result;
            }
            catch
            {
                RequestPid getPid = new RequestPid();
                return getPid.pid = null;
            }
        }

        /// <summary>
        /// 接口获取方法
        /// </summary>
        /// <returns></returns>
        public string GetMySelfDatum(string token, string pid,string url)
        {
            try
            {
                string result = "";

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                req.Method = "POST";

                req.ContentType = "application/json";

                //添加token
                req.Headers.Add("Api-Token", token);

                byte[] data = Encoding.UTF8.GetBytes(pid);

                req.ContentLength = data.Length;

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);

                    reqStream.Close();
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream stream = resp.GetResponseStream();

                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                //LogUtility.Debug("DealHttpRequestBll|GetMySelfDatum", result);
                return result;
            }
            catch (Exception ex)
            {
                LogUtility.Error("DealHttpRequestBll|GetMySelfDatum", ex.Message);
                return "";
            }
        }
        


        /// <summary>
        /// 获取健康档案
        /// </summary>
        /// <param name="idCard"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public ResponseTotleInfo GetHealthDatumInfo(string idCard, string passWord)
        {
           
            //1、获取token

            string Token = GetToken();
            RequestToken gToken = ObjectToJson.CopyObjectProperty<RequestToken>(new RequestToken(), Token);
            string _token = gToken.data;
            //LogUtility.Debug("GetHealthDatumInfo|获取token值", _token);


            //bool isGetToken = true;
            ResponseTotleInfo resposeInfo = new ResponseTotleInfo();

            if (!string.IsNullOrEmpty(_token))
            {
                //2、获取pid 通过返回pid接口返回的json消息判断是否成功
                //获取pid
                string Pid = GetPid(_token, idCard, passWord);
                //LogUtility.Debug("查看Pid", Pid);


                if (Pid != null)
                {
                    RequestPid getPid = ObjectToJson.CopyObjectProperty<RequestPid>(new RequestPid(), Pid);
                    string pids = ObjectToJson.GetObjectToString(new { pid = getPid.pid });
                    LogUtility.Debug("查看pids", pids);

                    ResponseDataInfo _data = new ResponseDataInfo();
                    //_1、调用个人信息接口
                    string MySelfDatum = GetMySelfDatum(_token, pids,AppConfig.m_getBasicResources);
                    _data.MySelfInfo = MySelfDatum;
                    //获取个人健康信息
                    string HealthCondition = GetMySelfDatum(_token, pids, AppConfig.m_gethealthCondition);
                    _data.getHealthCondition = HealthCondition;
                    //获取健康档案接口
                    string jkda = GetMySelfDatum(_token, pids,AppConfig.m_getjkda);
                    _data.HealthDatumInfo = jkda;
                    //把数据放入总实体当中
                    resposeInfo.dataContent = ObjectToJson.GetObjectToString(_data);
                }
                else
                {
                    resposeInfo.Code = 2;
                    resposeInfo.Msg = "不存在此人档案！";
                    resposeInfo.dataContent = "不存在此人档案";
                }
            }
            else
            {
                LogUtility.Debug("token获取失败", _token);
                resposeInfo.Code = 1;
                resposeInfo.Msg = "获取token失败";
            }
            return resposeInfo;
        }

    }
}
