using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Core.Helper
{
    public class StringHelper
    {
        public static string FormatDate(string date)
        {
            if (date.Length != 8)
            {
                throw new ArgumentException("Date string must be exactly 8 characters long.");
            }
            string month = date.Substring(0, 2);
            string day = date.Substring(2, 2);
            string year = date.Substring(4, 4);
            string formattedDate = $"{day}/{month}/{year}";

            return formattedDate;
        }
    }
}
