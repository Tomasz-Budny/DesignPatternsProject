using System;
using System.Threading;

namespace DesignPatternsProject
{
    class Program
    {
        public static void ParkingSimulator()
        {
            ParkingManager parkingManager = new ParkingManager(100);
            var instruction =
                "Wybierz co chcesz zrobić:\n  * Q - Wyjdź z programu\n  * I - Dodaj nowy samochód\n  * O - Zabierz samochód o konkretnej rejestracji z postoju\n";

            Console.WriteLine(instruction);
            while (true)
            {
                Console.Write("\nPodaj rodzaj operacji (I/O): ");
                var operation = Console.ReadLine();

                if (operation == "I")
                {
                    Console.Write("Podaj numer rejestracyjny: ");
                    var registrationNumber =  Console.ReadLine() ?? "";
                    parkingManager.Subscribe(new Car(registrationNumber));
                }
                else if (operation == "O")
                {
                    Console.Write("Podaj numer rejestracyjny: ");
                    var registrationNumber =  Console.ReadLine() ?? "";
                    parkingManager.RemoveCar(registrationNumber);
                }
                else if (operation == "Q")
                {
                    Console.WriteLine("\n##############################################");
                    Console.WriteLine("Dziękujemy za skorzystanie z parkomatu 3000!");
                    Console.WriteLine("##############################################");
                    break;
                }
                else
                {
                    Console.WriteLine("Operacja niepoprawna!");
                }  
            }
        }
        
        static void Main(string[] args)
        {
            // ParkingManager parkingManager = new ParkingManager();
            //
            // parkingManager.Subscribe(new Car("WWA2137"));
            // Thread.Sleep(2000);
            // parkingManager.Subscribe(new Car("WWA42069"));
            // Thread.Sleep(3000);
            // parkingManager.RemoveCar("WWA2137");
            //
            // parkingManager.Subscribe(new Car("WWA66647"));
            // Thread.Sleep(1000);
            // parkingManager.RemoveCar("WWA66647");
            
            ParkingSimulator();
        }
    }
}