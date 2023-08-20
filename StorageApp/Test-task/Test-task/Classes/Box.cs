using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Classses
{   
    public class Box : Product // класс, описывающий коробки
    {
        public DateTime ExpirationDate { get; set; }

        public DateTime ProductionDate { get; set; }

        public double Weight { get; set; }

        public Box(int id, double width, double height, double depth, double weight, DateTime productionDate)
            : base(id, width, height, depth)
        {
            ProductionDate = productionDate;
            ExpirationDate = productionDate.AddDays(100);

             if (!WeightCheck(weight))
                throw new ArgumentException("Size must be greater than 0.");
            Weight = weight;
        }
        public double CalculateVolume()
        {
            return Width * Height * Depth;
        }
        public static bool WeightCheck(double weight)
        {
            return !(weight <= 0);
        }

    }
}
