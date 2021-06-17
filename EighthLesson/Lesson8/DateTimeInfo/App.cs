using System;
using System.Reflection;

namespace DateTimeInfo
{
    internal class App
    {

        public void AppStart()
        {
            DateTime dt = DateTime.Now;
            ShowTypeInfo(dt);
        }

        public void ShowTypeInfo(DateTime dt)
        {
            Console.WriteLine("Namespace: " + dt.GetType().Namespace);

            var constructors = typeof(DateTime).GetConstructors();

            Console.WriteLine("\n------------Constructors------------\n");

            ShowElements(constructors);

            var interfaceses = typeof(DateTime).GetInterfaces();

            Console.WriteLine("\n------------Interfaceses------------\n");

            ShowElements(interfaceses);

            var filds = typeof(DateTime).GetFields();

            Console.WriteLine("\n------------Public Filds------------\n");

            ShowElements(filds);

            Console.WriteLine("\n------------Private Filds-----------\n");

            var pFilds = typeof(DateTime).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            ShowElements(pFilds);

            Console.WriteLine("\n-----------Public Methods-----------\n");

            var methods = dt.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);

            ShowElements(methods);

            Console.WriteLine("\n-----------Private Methods----------\n");

            var pMethods = dt.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            ShowElements(pMethods);
        }

        public void ShowElements(object[] arr)
        {
            foreach (var element in arr)
            {
                Console.WriteLine(element);
            }
        }

    }
}