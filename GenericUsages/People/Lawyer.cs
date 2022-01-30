using GenericUsages.Interfaces;
using System;

namespace GenericUsages.Entities
{
    public class Lawyer : Person, IProfessional
    {
        public void DoProfessionalThing()
        {
            // do some master piece..
        }
    }
}
