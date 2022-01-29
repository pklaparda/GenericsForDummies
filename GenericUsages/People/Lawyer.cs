using GenericUsages.Interfaces;

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
