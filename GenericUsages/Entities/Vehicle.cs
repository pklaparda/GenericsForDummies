namespace GenericUsages.Entities
{
    public enum Vehicles
    {
        Car,
        Truck,
        Bike
    }

    public class Vehicle<T> 
    {
        public Vehicle(T id, Vehicles type) {
            Id = id;
            Type = type;
        }

        public T Id { get; set; }
        public Vehicles Type { get; set; }

        public void Ride() { }
    }
}
