using System;

namespace GenericUsages.Entities
{
    public class Laptop : Workstation<Guid>, IWorkstation
    {
        public Laptop(Guid serialNumber) : base(serialNumber)
        {
        }

        public string GetSerialNumber() => SerialNumber.ToString();

        public void ProcessData() => Console.WriteLine("Laptop processing data...");
    }
}
