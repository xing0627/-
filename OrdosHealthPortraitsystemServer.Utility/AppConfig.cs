using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OrdosHealthPortraitsystemServer.Utility
{
    public class AppConfig
    {
        /// <summary>
        /// 获取token地址
        /// </summary>
        public static string m_getTokenUrl = ConfigurationManager.AppSettings["getTokenUrl"].ToString();

        /// <summary>
        /// 获取被调阅人唯一id
        /// </summary>
        public static string m_getPid = ConfigurationManager.AppSettings["getPid"].ToString();

        /// <summary>
        /// 日志文件保存路径
        /// </summary>
        public static string m_LogFilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
        /// <summary>
        /// 个人基本信息
        /// </summary>
        public static string m_getBasicResources = ConfigurationManager.AppSettings["getBasicResources"].ToString();
        /// <summary>
        /// 个人健康状况
        /// </summary>
        public static string m_gethealthCondition = ConfigurationManager.AppSettings["gethealthCondition"].ToString();
        /// <summary>
        /// 个人健康档案信息
        /// </summary>
        public static string m_getjkda = ConfigurationManager.AppSettings["getjkda"].ToString();
        
        
    }
}
