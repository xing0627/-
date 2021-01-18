using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.Script.Serialization;

namespace OrdosHealthPortraitsystemServer.Utility
{
    public class ObjectToJson
    {
        /// <summary>
        /// 对象转换为发送流
        /// </summary>
        /// <param name="data"></param>
        /// <param name="response"></param>
        public static byte[] GetObjectTobytes(object data)
        {
            byte[] buffer = null;
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer jser = new System.Web.Script.Serialization.JavaScriptSerializer();
                string responseString = jser.Serialize(data);
                buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            }
            catch (Exception ex)
            {
                LogUtility.Error("GetObjectTobytes", ex.ToString());
            }
            return buffer;

        }

        /// <summary>
        /// 对象转换为json字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="response"></param>
        public static string GetObjectToString(object data)
        {
            string responseString = "";
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer jser = new System.Web.Script.Serialization.JavaScriptSerializer();
                responseString = jser.Serialize(data);

            }
            catch (Exception ex)
            {
                LogUtility.Error("GetObjectToString", ex.ToString());
            }
            return responseString;

        }

        /// <summary>
        /// json字符串转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tSource"></param>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        public static T CopyObjectProperty<T>(T tSource, string jsonstr) where T : class
        {
            //获得所有property的信息
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            tSource = serializer.Deserialize<T>(jsonstr);
            return tSource;
        }
    }
}
