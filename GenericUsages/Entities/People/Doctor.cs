using GenericUsages.Interfaces;

namespace GenericUsages.Entities
{
    public class Doctor : Person, IProfessional
    {
        public void DoProfessionalThing()
        {
            // do some master piece..
        }
    }
}
