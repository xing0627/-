using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdosHealthPortraitsystemServer.Model
{
    public class RequestPid
    {
        /// <summary>
        /// resultCode
        /// </summary>
        public int resultCode { get; set; }
        /// <summary>
        /// resultDesc
        /// </summary>
        public string resultDesc { get; set; }
        /// <summary>
        /// resultType
        /// </summary>
        public string resultType { get; set; }
        /// <summary>
        /// type
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// accessType
        /// </summary>
        public string accessType { get; set; }

        /// <summary>
        /// pid
        /// </summary>
        public string pid { get; set; }
        /// <summary>
        /// cardType
        /// </summary>
        public string cardType { get; set; }
        /// <summary>
        /// idCard
        /// </summary>
        public string idCard { get; set; }
        /// <summary>
        /// medicalOrgId
        /// </summary>
        public string medicalOrgId { get; set; }
        /// <summary>
        /// officeId
        /// </summary>
        public string officeId { get; set; }
        /// <summary>
        /// jobId
        /// </summary>
        public string jobId { get; set; }
        /// <summary>
        /// isCheckNeedPsd
        /// </summary>
        public string isCheckNeedPsd { get; set; }
        /// <summary>
        /// liveType
        /// </summary>
        public string liveType { get; set; }




    }
}
