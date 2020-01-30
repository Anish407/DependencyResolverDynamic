using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyResolverDynamic
{
    class Program
    {
        /// <summary>
        /// A method that takes a class that has been registererd with a generic interface, 
        /// pass the arguement and we dynamically create the instance of the class and pass the value to it
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var provider = RegisterDI();

      
            ExecuteShow(new MyVM { myVal=1}, provider);
            ExecuteShow(new MyVM2 { myVal=2}, provider);


            Console.ReadLine();
        }

        public static IServiceProvider RegisterDI()
        {
            var services = new ServiceCollection();

            services.AddScoped<IMyClass<MyVM>, MyClass>();
            services.AddScoped<IMyClass<MyVM2>, MyClass2>();

            return services.BuildServiceProvider();
        }

        static void ExecuteShow(IMarker myType, IServiceProvider serviceProvider)
        {
            Type type = typeof(IMyClass<>);
            Type[] typeArg = { myType.GetType() };
            Type myCLassType = type.MakeGenericType(typeArg);

            dynamic instance = serviceProvider.GetService(myCLassType);
            instance.show(myType);

        }

        interface IMyClass<T>
        {
            void show(IMarker marker);
        }

        interface IMarker
        {
            public int myVal { get; set; }
        }

        class MyVM: IMarker
        {
            public int myVal { get; set; }
        }

        class MyVM2: IMarker
        {
            public int myVal { get; set; }
        }


        class MyClass : IMyClass<MyVM>
        {
            public int MyProperty { get; set; }

            public void show(IMarker marker)
            {
                Console.WriteLine(marker.myVal);
            }
        }

        class MyClass2 : IMyClass<MyVM2>
        {
            public int MyProperty { get; set; }

            public void show(IMarker marker)
            {
                Console.WriteLine(marker.myVal);
            }
        }
    }
}
