/*
Составить описание класса для объектов-векторов, задаваемых модулем (длиной) и углом
относительно оси абсцисс. Обеспечить операции сложения и вычитания векторов с получением
нового вектора (суммы и разности), вычисления скалярного произведения двух векторов. Все
операции реализовать в виде перегрузки операторов. Программа должна содержать меню,
позволяющее осуществлять проверку всех методов.
*/

 
using System;
using System.Collections.Generic;

namespace labs {

    class lab2 {
        public void Main2() {
            // Меню
            while (true) {
                Console.WriteLine("FUNCTION: addition, subtruction and scalar");
                string func = Console.ReadLine();
                if (func == "addition") {
                    Vector a = InputVector();
                    Vector b = InputVector();
                    Vector c = new Operation().Addition(a, b);
                    Console.WriteLine("({0} ; {1})", c.GetModule(), c.GetAngle() * 180 / Math.PI);
                } else if (func == "subtruction") {
                    Vector a = InputVector();
                    Vector b = InputVector();
                    Vector c = new Operation().Subtraction(a, b);
                    Console.WriteLine("({0} ; {1})", c.GetModule(), c.GetAngle() * 180 / Math.PI);
                } else if (func == "scalar") {
                    Vector a = InputVector();
                    Vector b = InputVector();
                    double Scalar = new Operation().ScalarComposition(a, b);
                    Console.WriteLine(Scalar);
                }
                Console.WriteLine("\nDO YOU WANT TO CONTINUE? y or n");
                string cont = Console.ReadLine();
                if (cont == "n") {
                    break;
                }
            }
        }

        static Vector InputVector() {
            Console.WriteLine("Enter a module of vector");
            double module = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter angle between vector and axis");
            double angle = Math.PI * Convert.ToDouble(Console.ReadLine()) / 180.0;
            return new Vector(module, angle);
        }
    }

    class Operation {
        public Vector Addition(Vector a, Vector b) {
            return a + b;
        }
        public Vector Subtraction(Vector a, Vector b) {
            return a - b;
        }
        public double ScalarComposition(Vector a, Vector b) {
            return a * b;
        }
    }
    class Vector {
        private double Module;
        private double Angle;
        
        public Vector() {}
        public Vector(double module, double angle) {
            Module = module;
            Angle = angle;
        }
        public double GetModule() {
            return Module;
        }
        public double GetAngle() {
            return Angle;
        }
        public static Vector operator +(Vector a, Vector b) {
            double module = Math.Sqrt(Math.Pow((a.GetCoordinateX() + b.GetCoordinateX()), 2) +
            Math.Pow((a.GetCoordinateY() + b.GetCoordinateY()), 2));
            double x = a.GetCoordinateX() + b.GetCoordinateX();
            double angle = Math.Acos(x/module);
            return new Vector { Module = module, Angle = angle };
        }

        public static Vector operator -(Vector a, Vector b) {
            double module = Math.Sqrt(Math.Pow((a.GetCoordinateX() - b.GetCoordinateX()), 2) +
            Math.Pow((a.GetCoordinateY() - b.GetCoordinateY()), 2));
            double x = a.GetCoordinateX() - b.GetCoordinateX();
            double angle = Math.Acos(x/module);
            return new Vector { Module = module, Angle = angle };
        }

        public static double operator *(Vector a, Vector b) {
            return a.GetCoordinateX() * b.GetCoordinateX() + a.GetCoordinateY() * b.GetCoordinateY();
        }

        public double GetCoordinateX() {
            return Module * Math.Cos(Angle);
        }

        public double GetCoordinateY() {
            double x = GetCoordinateX();
            return Math.Sqrt(Math.Pow(Module, 2) - Math.Pow(x, 2));
        }
    }
}