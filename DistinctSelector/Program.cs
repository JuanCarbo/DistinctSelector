using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace DistinctSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            IEnumerable<ClassExample> numbers = new List<ClassExample> {
                new ClassExample(){Nombre = "Juan", Apellido = "Carbó"},
                new ClassExample(){Nombre = "Mechi", Apellido = "Carbó"},
                new ClassExample(){Nombre = "Mechi", Apellido = "Carbó"},
                new ClassExample(){Nombre = "Juan", Apellido = "Suare"},
                new ClassExample(){Nombre = "Juan", Apellido = "Sancho"},
                new ClassExample(){Nombre = "Juan", Apellido = "Perez"},
                new ClassExample(){Nombre = "Mechi", Apellido = "Carbó"},
                new ClassExample(){Nombre = "Mechi", Apellido = "Carbó"},
            };
            foreach (ClassExample exampleEntity in numbers)
            {
                if (hashtable.ContainsKey(exampleEntity.Nombre))
                    ((List<ClassExample>) hashtable[exampleEntity.Nombre]).Add(exampleEntity);
                else
                {
                    hashtable[exampleEntity.Nombre] = new List<ClassExample>() { exampleEntity};
                }
            }
            foreach (DictionaryEntry keyVal in hashtable)
            {
                Console.WriteLine($"Value {keyVal.Key} Times {((IEnumerable<ClassExample>)keyVal.Value).Count()}");
                foreach(var exampleData in ((IEnumerable<ClassExample>)keyVal.Value))
                {
                    Console.WriteLine($"{exampleData.Nombre} { exampleData.Apellido}");
                }
            }
            Console.ReadLine();
        }
    }

    internal class ClassExample
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
