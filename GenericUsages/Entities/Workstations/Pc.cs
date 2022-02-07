using System;

namespace GenericUsages.Entities
{
    public class Pc : Workstation<long>, IWorkstation
    {
        public Pc(long serialNumber): base(serialNumber)
        {
        }

        public string GetSerialNumber() => SerialNumber.ToString();

        public void ProcessData() => Console.WriteLine("Pc processing data...");
    }
}
