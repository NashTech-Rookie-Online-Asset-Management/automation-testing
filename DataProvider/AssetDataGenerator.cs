using System;
using System.Collections.Generic;
using AssetManagement.Models.Create;
using Bogus;

namespace AssetManagement.DataProvider
{
    public static class AssetDataGenerator
    {
        private static readonly Random Random = new Random();
        private static readonly Faker Faker = new Faker();

        private static readonly Dictionary<string, string[]> BrandMapping = new Dictionary<string, string[]>
        {
            { "Laptop", new[] { "Dell", "Macbook", "HP", "MSI", "Acer" } },
            { "Personal Computer", new[] { "HP", "Dell", "Lenovo", "Asus", "Acer" } },
            { "Bluetooth", new[] { "JBL", "Sony", "Bose", "Sennheiser", "Beats" } },
            { "Headphone", new[] { "Sony", "Bose", "Beats", "Sennheiser", "Audio-Technica" } },
            { "Keyboard", new[] { "Logitech", "Razer", "Corsair", "SteelSeries", "Microsoft" } },
            { "Mouse", new[] { "Razer", "Logitech", "SteelSeries", "Corsair", "Microsoft" } }
        };

        private static readonly Dictionary<string, string[]> SpecificationMapping = new Dictionary<string, string[]>
        {
            { "Laptop", new[] { "i7-1165G7, 16GB RAM, 512GB SSD", "i5-10210U, 8GB RAM, 256GB SSD", "Ryzen 7 4800H, 16GB RAM, 1TB SSD", "i7-10750H, 16GB RAM, 512GB SSD", "i3-1005G1, 4GB RAM, 128GB SSD" } },
            { "Personal Computer", new[] { "i7-9700K, 16GB RAM, 1TB SSD, RTX 2070", "i5-9600K, 8GB RAM, 512GB SSD, GTX 1660", "Ryzen 5 3600, 16GB RAM, 1TB SSD, RX 5700 XT", "i9-9900K, 32GB RAM, 2TB SSD, RTX 2080 Ti", "Ryzen 7 3700X, 16GB RAM, 1TB SSD, RTX 2060" } },
            { "Bluetooth", new[] { "Version 4.0", "Version 4.1", "Version 4.2", "Version 5.0", "Version 5.1" } },
            { "Headphone", new[] { "Over-Ear, Noise Cancelling", "In-Ear, Bass Boosted", "Over-Ear, Studio Quality", "In-Ear, Wireless", "Over-Ear, Wireless" } },
            { "Keyboard", new[] { "Mechanical, RGB Lighting", "Membrane, Quiet Keys", "Mechanical, Compact", "Mechanical, Ergonomic", "Membrane, Wireless" } },
            { "Mouse", new[] { "Ergonomic, Optical Sensor", "Gaming, High DPI", "Wireless, Rechargeable", "Wired, RGB Lighting", "Compact, Portable" } }
        };

        public static AssetCreate GenerateSingleAsset()
        {
            string name = GenerateName(out string category);
            string specification = GenerateSpecification(category);

            return new AssetCreate
            {
                Name = name,
                Category = category,
                Specification = specification,
                InstalledDate = GenerateRandomDate().ToString("MMddyyyy"),
                State = Random.Next(0, 2) == 0 ? "Available" : "Not Available"
            };
        }

        private static string GenerateName(out string category)
        {
            List<string> keys = new List<string>(BrandMapping.Keys);
            string randomKey = keys[Random.Next(keys.Count)];
            category = randomKey;

            string brand = BrandMapping[randomKey][Random.Next(BrandMapping[randomKey].Length)];
            return $"{randomKey} {brand}";
        }

        private static string GenerateSpecification(string category)
        {
            return SpecificationMapping[category][Random.Next(SpecificationMapping[category].Length)];
        }

        private static DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Random.Next(range));
        }
    }

 
}
