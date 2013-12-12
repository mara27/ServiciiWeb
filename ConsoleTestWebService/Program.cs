using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleTestWebService
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Get Iasi Weather\n");
            //GetIasiWeather();

            //Console.WriteLine("\n");
            //Console.WriteLine("\n TempConvert \n");
            //TempConvert();

            //Console.WriteLine("\n");
            //Console.WriteLine("\n Calculator \n");
            //Calculator();

            //Console.ReadKey();

            localhost.EmployeesWebService sw = new localhost.EmployeesWebService();

            //GetAll()
            Console.WriteLine("\n Apelarea metodei GetAll() \n");
            var all = sw.GetAll();
            Console.WriteLine("All employees: \n");
            foreach (var emp in all)
            {

                var manager = (emp.Manager == null) ? "Fara manager" : emp.Manager.FirstName;

                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Salary + " " + manager);
            }

            //Get(id)
            Console.WriteLine("\n Apelarea metodei Get(id) \n");
            var get = sw.Get(3);
            Console.WriteLine("\n Get(3)");
            Console.WriteLine(get.FirstName + " " + get.LastName + "\n");

            //Create
            Console.WriteLine("\n Apelarea metodei Create \n");
            string firstName = "Alia";
            string lastName = "Hugo";
            double salary = 200;
            sw.Create(firstName, lastName, salary);
            all = sw.GetAll();
            foreach (var emp in all)
            {

                var manager = (emp.Manager == null) ? "Fara manager" : emp.Manager.FirstName;

                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Salary + " " + manager);
            }

            //Update
            Console.WriteLine("\n Apelarea metodei Update \n");
            Console.WriteLine("\n Inainte de Update \n");
            all = sw.GetAll();
            foreach (var emp in all)
            {

                var manager = (emp.Manager == null) ? "Fara manager" : emp.Manager.FirstName;

                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Salary + " " + manager);
            }
            var forUp = sw.Get(1);
            forUp.Salary = 500;
            sw.Update(forUp);
            Console.WriteLine("\n Dupa Update \n");
            all = sw.GetAll();
            foreach (var emp in all)
            {

                var manager = (emp.Manager == null) ? "Fara manager" : emp.Manager.FirstName;

                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Salary + " " + manager);
            }

            //Delete
            Console.WriteLine("\n Apelarea metodei Delete(id) \n ");
            Console.WriteLine("\n Inainte de Delete \n");
            all = sw.GetAll();
            foreach (var emp in all)
            {

                var manager = (emp.Manager == null) ? "Fara manager" : emp.Manager.FirstName;

                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Salary + " " + manager);
            }
            sw.Delete(3);
            sw.Delete(5);
            Console.WriteLine("\n Dupa Delete \n");
            all = sw.GetAll();
            foreach (var emp in all)
            {

                var manager = (emp.Manager == null) ? "Fara manager" : emp.Manager.FirstName;

                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Salary + " " + manager);
            }

            Console.ReadKey();
        }

        static void GetIasiWeather()
        {
            com.webservicex.www.GlobalWeather gw = new com.webservicex.www.GlobalWeather();
            var result = gw.GetWeather("Iasi", "Romania");
            Console.Write(result, "\n");
        }

        static void TempConvert()
        {
            com.w3schools.www.TempConvert tc = new com.w3schools.www.TempConvert();
            var result = tc.CelsiusToFahrenheit("-5");
            Console.Write(result, "\n");
        }

        static void Calculator()
        {
            WebServices.Calculator calc = new WebServices.Calculator();
            var resultHello = calc.HelloWorld();
            Console.Write(resultHello, "\n");
            var resultSum = calc.Sum(4, 8);
            Console.WriteLine("\n");
            Console.WriteLine("Result Sum: " + resultSum, "\n");
        }

 
    }
}
