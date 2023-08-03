using ReflectionAssignment22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAssignment22
{
    public class Program
    {
        public static void MapProperties(Source Source,Destination Destination)
        {
            Type sourceType = typeof(Source);
            Type destinationType = typeof(Destination);

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] destinationProperties = destinationType.GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo destinationProperty = Array.Find(destinationProperties,
                    p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);

                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    object value = sourceProperty.GetValue(Source);
                    destinationProperty.SetValue(Destination, value);
                }
            }
        }

        static void Main(string[] args)
        {
            Source source = new Source
            {
                Name = "SRAVS",
                Age =23,

            };

            Destination destination = new Destination
            {
                Id = 101,
                Class = "Tenth Class"
            };

            MapProperties(source, destination);

            Console.WriteLine("  Mapping Successful!!!");
            Console.WriteLine("=========================");
            Console.WriteLine("Name: " + destination.Name);
            Console.WriteLine("Age: " + destination.Age);
            Console.WriteLine("ID: " + destination.Id);
            Console.WriteLine("Class: " + destination.Class);

            Console.ReadKey();
        }



    }
}
        
    


