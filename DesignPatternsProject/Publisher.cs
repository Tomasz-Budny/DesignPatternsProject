using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Channels;
using System.Timers;

namespace DesignPatternsProject
{
    public interface IPublisher
    {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void NotifySubscribers();
    }

    public class ParkingManager : IPublisher
    {
        private readonly List<ISubscriber> _cars = new List<ISubscriber>();
        private int _freeSpace;
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public ParkingManager(int freeSpace)
        {
            _freeSpace = freeSpace;
        }

        public void Subscribe(ISubscriber subscriber)
        {
            if (subscriber == null) return;
            if (_freeSpace == 0)
            {
                Console.WriteLine("Błąd! Brakuje wolnych miejsc na parkingu!");
                return;
            }

            NotifySubscribers();
            _cars.Add(subscriber);
            UpdateFreeSpace(-1);
        }

        public void RemoveCar(string registrationNumber)
        {
            Car carToRemove = null;
            foreach (var car in _cars)
            {
                if (((Car)car).RegistrationNumber == registrationNumber)
                {
                    carToRemove = ((Car)car);
                    break;
                }
            }

            if (carToRemove == null)
            {
                Console.WriteLine("Błąd! Brak samochodu o takim numerze!");
                return;
            }

            Unsubscribe(carToRemove);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            if (subscriber == null) return;

            NotifySubscribers();
            _cars.Remove(subscriber);
            UpdateFreeSpace(1);

            var timeAtParking = ((Car)subscriber).TimeAtParking;
            var price = Math.Round(timeAtParking / 10000 * 0.1, 5);
            
            Console.WriteLine($"Samochód przebywał na parkingu: {timeAtParking / 1000} sekund");
            Console.WriteLine($"Do drukarki wysłano paragon o wartości: {price} PLN");
        }

        public void NotifySubscribers()
        {
            _stopwatch.Stop();
            foreach (var car in _cars)
            {
                car.Update(_stopwatch.ElapsedMilliseconds);
            }
            _stopwatch.Restart();
        }

        private void UpdateFreeSpace(int spacetaken)
        {
            _freeSpace += spacetaken;
            Console.WriteLine($"Liczba wolnych miejsc postojowych: {_freeSpace}");
        }
    }
}