namespace GenericUsages.Entities
{
    public class Person
    {
        public override string ToString()
        {
            return $"I'm a {GetType().Name}";
        }
    }
}
