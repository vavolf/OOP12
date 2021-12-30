using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = "lab12.Product";
            Reflector<int>.GetAssemblyName(type);
            Reflector<int>.HasPublicConstructors(type);
            Reflector<int>.GetPublicMethods(type);
            Reflector<int>.GetFieldsAndProperties(type);
            Reflector<int>.GetInterfacesOfType(type);
            Reflector<int>.ShowMethodsByParameters(type, "System.String");

            Reflector<int>.Invoke("ToString", "lab12.Game");
            Console.WriteLine(Reflector<Game>.Create("lab12.Game", arguments: "DOOM"));

            Console.ReadKey();
        }
    }
}