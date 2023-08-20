using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Classses
{
    public class Pallet : Product// класс, описывающий паллету
    {
        public List<Box> Boxes { get; set; }
        
        public Pallet(int id, double width, double height, double depth)
            : base(id, width, height, depth)
        {
            Boxes = new List<Box>();
        }

        public void AddBox(Box box) 
        {
            if (box.Width <= Width && box.Depth <= Depth)
            {
                Boxes.Add(box);
            }
            else
            {
                Console.WriteLine($"Box {box.Id} is too big for this pallet.");
            }
        }

        public DateTime CalculateExpirationDate()
        {
            DateTime expirationDate = DateTime.MaxValue;
            foreach (var box in Boxes)
            {
                if (box.ExpirationDate < expirationDate)
                    expirationDate = box.ExpirationDate;
            }
            return expirationDate;
        }

        public double CalculateWeight()
        {
            double totalWeight = Boxes.Sum(box => box.Weight);
            return totalWeight + 30;
        }

        public double CalculateVolume()
        {
            double volumeSum = Boxes.Sum(box => box.CalculateVolume());
            return volumeSum + Width * Height * Depth;
        }

    }
}
