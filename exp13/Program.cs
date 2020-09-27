using System;

namespace exp13
{
    class Program
    {
        
        const double Pi = 3.14;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину верёвки");
            double length = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите длину стороны забора");
            double side = double.Parse(Console.ReadLine());

            double result = SquareCount (side, length);
            Console.WriteLine("Площадь съеденного поля = " + result);
        }
        
        public static double SquareCount (double side, double length)
        {
            double halfSide = side / 2;
            double squareOfSquare = side * side;
            double squareOfCircle = Pi * length * length;

            if (halfSide >= length)
            {
                return Pi * length * length;
            }
            else if (squareOfSquare > squareOfCircle)
            {
                double highOfSector = length - halfSide;
                double triangleBase = TriangleBase(length, highOfSector);
                double triangleSide = TriangleBase2(triangleBase, highOfSector);
                double smallHalfOfSector = 2 * triangleSide + (2 * triangleSide - 2 * triangleBase) / 3;

                return squareOfCircle - 4 * smallHalfOfSector;
            }
            else return squareOfSquare;
        }

        public static double TriangleBase (double side, double high)
        {
            return Math.Sqrt(side * side - high * high);
        }
        // не знаю как сделать одним методом с разными знаками, пробовал через char, не получилось
        public static double TriangleBase2 (double side, double high)
        {
            return Math.Sqrt(side * side + high * high);
        }
    }
}
