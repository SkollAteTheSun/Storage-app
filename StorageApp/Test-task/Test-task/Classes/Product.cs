using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classses
{
    public class Product // класс, описывающий товар на складе с общими свойствами
    {
        public int Id { get; set; } // идентификатор
        public double Width { get; set; } // ширина
        public double Height { get; set; } // высота
        public double Depth { get; set; } // глубина

        public Product(int id, double width, double height, double depth)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product ID.");

            if (!ParamsCheck(width, height, depth))
                throw new ArgumentException("Size must be greater than 0.");

            Id = id;
            Width = width;
            Height = height;
            Depth = depth;

        }

        public static bool ParamsCheck(double width, double length, double height)
        {
            return (!(width <= 0)) && (!(length <= 0)) && (!(height <= 0));
        }
        
    }
}

