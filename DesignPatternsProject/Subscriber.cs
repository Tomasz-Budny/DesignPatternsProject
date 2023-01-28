namespace DesignPatternsProject
{
    public interface ISubscriber
    {
        void Update(double time);
    }
    
    public class Car: ISubscriber
    {
        public string RegistrationNumber { get; set; }
        public double TimeAtParking { get; set; }

        public Car(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }
        
        public void Update(double time)
        {
            TimeAtParking += time;
        }
    }
}