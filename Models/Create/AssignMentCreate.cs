using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models.Create
{
    public class AssignMentCreate
    {
        public string StaffCode { get; set; }
        public string AssetCode { get; set; }

        [JsonProperty("Assigned date")]
        public string AssigneddDated { get; set; }
        public string Note { get; set; }
        public string State { get; set; }
    }
}
