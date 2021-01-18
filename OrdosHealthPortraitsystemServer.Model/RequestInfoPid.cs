using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdosHealthPortraitsystemServer.Model
{
    public class RequestInfoPid
    {
        /// <summary>
        /// 调阅方式
        /// </summary>
        public string accessType { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string idCard { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string cardType { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string passWord { get; set; }
        /// <summary>
        /// 调阅人平台台注册医疗机构代码
        /// </summary>
        public string medicalOrgId { get; set; }
        /// <summary>
        /// 调阅人平台台注册科室代码
        /// </summary>
        public string deptId {get;set;}
        /// <summary>
        /// 调阅人平台台注册工号
        /// </summary>
        public string jobNo { get; set;}
    }
}
