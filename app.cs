using System;
using System.Collections.Generic;

namespace labs {
    class app {
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("Which lab do you choose? Enter number))");
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
                } else {
                    Console.WriteLine("So, I do only two labs)");
                    break;
                }
            }
            
            
        }
    }
}