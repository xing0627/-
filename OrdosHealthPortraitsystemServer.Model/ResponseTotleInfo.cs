using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdosHealthPortraitsystemServer.Model
{
    /// <summary>
    /// 返回给页面总实体
    /// </summary>
    public class ResponseTotleInfo
    {
        /// <summary>
        /// 0:请求成功
        /// 1：token请求错误
        /// 2:pid请求错误
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 描述 
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据体
        /// </summary>
        public string dataContent { get; set; }
    }

    /// <summary>
    /// 健康档案数据
    /// </summary>
    public class ResponseDataInfo   
    {
        /// <summary>
        /// 个人信息
        /// </summary>
        public string MySelfInfo { get; set; }

        /// <summary>
        /// 健康档案信息
        /// </summary>
        public string HealthDatumInfo { get; set; }
        /// <summary>
        /// 个人健康信息
        /// </summary>
        public string getHealthCondition { get; set; }
    }
}
