using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace lab12
{
    class Reflector<T>
    {
        public static void GetAssemblyName(string className)
        {
            string assemblyName = Type.GetType(className).Assembly.FullName;
            Console.WriteLine(Type.GetType(className));
            using (StreamWriter sw = new StreamWriter(@"D:\C#\lab12\lab12\note.txt", true))
            {
                sw.WriteLine($"Имя сборки: {assemblyName}");
            }
        }

        public static void HasPublicConstructors(string className)
        {
            ConstructorInfo[] constructors = Type.GetType(className).GetConstructors();
            using (StreamWriter sw = new StreamWriter(@"D:\C#\lab12\lab12note.txt", true))
            {
                if (constructors.Length == 0)
                {
                    Console.WriteLine("Публичных конструкторов не найдено");
                    sw.WriteLine("Публичных конструкторов не найдено");
                }
                else
                {
                    Console.WriteLine("Есть публичные конструкторы");
                    sw.WriteLine("Есть публичные конструкторы");
                }
            }
        }
        public static void GetPublicMethods(string className)
        {
            MethodInfo[] methods = Type.GetType(className).GetMethods();
            using (StreamWriter sw = new StreamWriter(@"D:\C#\lab12\lab12\note.txt", true))
            {
                if (methods.Length == 0)
                {
                    Console.WriteLine("Публичных методов не найдено");
                    sw.WriteLine("Публичных методов не найдено");
                }
                else
                {
                    Console.WriteLine("Публичные методы:");
                    sw.WriteLine("Публичные методы:");
                    foreach (var method in methods)
                    {
                        Console.WriteLine(method);
                        sw.WriteLine(method);
                    }
                }
            }
        }
        public static void GetFieldsAndProperties(string className)
        {
            FieldInfo[] fields = Type.GetType(className).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo[] properties = Type.GetType(className).GetProperties();
            using (StreamWriter sw = new StreamWriter(@"D:\C#\lab12\lab12\note.txt", true))
            {
                if (fields.Length == 0)
                {
                    Console.WriteLine("Полей не найдено");
                    sw.WriteLine("Полей не найдено");
                }
                else
                {
                    Console.WriteLine("Поля:");
                    sw.WriteLine("Поля:");
                    foreach (var field in fields)
                    {
                        Console.WriteLine(field);
                        sw.WriteLine(field);
                    }
                }
                if (properties.Length == 0)
                {
                    Console.WriteLine("Свойств не найдено");
                    sw.WriteLine("Свойств не найдено");
                }
                else
                {
                    Console.WriteLine("Свойства:");
                    sw.WriteLine("Свойства:");
                    foreach (var property in properties)
                    {
                        Console.WriteLine(property);
                        sw.WriteLine(property);
                    }
                }
            }
        }
        public static void GetInterfacesOfType(string className)
        {
            Type[] interfaces = Type.GetType(className).GetInterfaces();
            using (StreamWriter sw = new StreamWriter(@"D:\C#\lab12\lab12\note.txt", true))
            {
                if (interfaces.Length == 0)
                {
                    Console.WriteLine("Реализуемых интерфейсов не найдено");
                    sw.WriteLine("Реализуемых интерфейсов не найдено");
                }
                else
                {
                    Console.WriteLine("Реализуемые интерфейсы:");
                    sw.WriteLine("Реализуемые интерфейсы:");
                    foreach (var interf in interfaces)
                    {
                        Console.WriteLine(interf);
                        sw.WriteLine(interf);
                    }
                }
            }
        }
        public static void ShowMethodsByParameters(string className, string paramType)
        {
            Type parameter = Type.GetType(paramType);
            Console.WriteLine($"Методы с типом параметра, соответствующим {parameter}");
            using (StreamWriter sw = new StreamWriter(@"D:\C#\lab12\lab12\note.txt", true))
            {
                bool flag = false;
                foreach (MethodInfo method in Type.GetType(className).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic))
                {
                    foreach (ParameterInfo param in method.GetParameters())
                    {
                        if (parameter.Equals(param.ParameterType))
                        {
                            flag = true;
                            Console.WriteLine(method);
                            sw.WriteLine(method);
                        }
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("Не найдено методов с соответствующим типом параметров");
                    sw.WriteLine("Не найдено методов с соответствующим типом параметров");
                }
            }

        }

        public static void Invoke(string method, string className)
        {
            Type type = Type.GetType(className);
            var obj = Activator.CreateInstance(type);
            MethodInfo getMethod = type.GetMethod(method);
            var result = getMethod.Invoke(obj, null);
            Console.WriteLine(result);
        }

        public static T Create(string className, params object[] arguments)
        {
            Type type = Type.GetType(className);
            //var obj = (T)Activator.CreateInstance(type);
            var obj = arguments.Length == 0 ? (T)Activator.CreateInstance(type) : (T)Activator.CreateInstance(type, arguments);

            return obj;
        }
    }
}