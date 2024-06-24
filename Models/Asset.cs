using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Asset
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Specification { get; set; }
        public string InstalledDate { get; set; }
        public string State { get; set; }
    }
}
