using System;

namespace labs {
    class app {
        static void Main(string[] args) {

            while (true) {

                Console.WriteLine("Which lab do you choose? Enter number");

                string lab = Console.ReadLine();

                if (lab == "0") {

                    lab0 Lab0 = new lab0();
                    Lab0.Main0();

                } else if (lab == "1") {

                    lab1 Lab1 = new lab1();
                    Lab1.Main1();

                } else if (lab == "2") {

                    lab2 Lab2 = new lab2();
                    Lab2.Main2();

                } else if (lab == "3") {

                    lab3 Lab3 = new lab3();
                    Lab3.Main3();

                } else if (lab == "4") {

                    lab4 Lab4 = new lab4();
                    Lab4.Main4();

                } else break;
                
            }
        }
    }
}