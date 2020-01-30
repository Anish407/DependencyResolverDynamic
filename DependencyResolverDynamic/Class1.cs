using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyResolverDynamic
{
    class Class1
    {

        void trial()
        {
            MyClass cl = new MyClass();
            IInterface c2 = new MyClass();

            // sample(c1); doesnt work
            sample(c2);
            //sample2(c2);
            //sample3(c2);
        }

        void sample(IInterface inter)
        {

        }

        void sample2(IInterface2 inter)
        {

        }
        void sample3(MyClass inter)
        {

        }
    }

    interface IInterface
    {

    }

    interface IInterface2
    {
        void show();
    }

    class MyClass : IInterface, IInterface2
    {
        public void show()
        {
            Console.WriteLine("my class");
        }
    }
}
