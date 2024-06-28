using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models.Edit
{
    public class AssetEdit
    {
        public string assetCode { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public string InstalledDate { get; set; }
        public string State { get; set; }
    }
}
