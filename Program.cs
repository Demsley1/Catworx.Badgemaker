// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System;
using System.Drawing;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // This is our employee-getting code now
            List<Employee> employees = new List<Employee>();

            //employees = PeopleFetcher.GetEmployees();
            employees = await PeopleFetcher.GetFromAPI();

            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}





/*double side = 3.14;
            double area = side * side;
            Console.WriteLine("area is a {0}", area.GetType());
            string greeting = "Hello";
            greeting = greeting + "World";
            Console.WriteLine("greeting" + greeting);
           // Console.WriteLine("Hello, World!");
            Console.WriteLine(2 * 3);         // Basic Arithmetic: +, -, /, *
            Console.WriteLine(10 % 3);        // Modulus Op => remainder of 10/3
            Console.WriteLine(1 + 2 * 3);     // order of operations
            Console.WriteLine(10 / 3.0);      // int's and doubles
            Console.WriteLine(10 / 3);        // int's 
            Console.WriteLine("12" + "3");    // What happens here?
            int num = 10;
            num += 100;
            Console.WriteLine(num);
            num ++;
            Console.WriteLine(num);*/