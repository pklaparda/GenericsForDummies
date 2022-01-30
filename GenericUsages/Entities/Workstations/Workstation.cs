namespace GenericUsages.Entities
{
    public abstract class Workstation<T> where T : struct
    {
        public T SerialNumber { get; set; }
        public Workstation(T serialNumber)
        {
            SerialNumber = serialNumber;
        }

    }


    // the struct constrain will prevent any dev in the future to create a machine with an object as Serial Number
    // even strings, cuz they can be null...
    //public class Celphone : Workstation<string>
    //{
    //    public Celphone(string serialNumber) : base(serialNumber)
    //    {
    //    }
    //}
}
