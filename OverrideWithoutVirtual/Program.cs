using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n* Results from BaseClass:\n");

        BaseClass baseClass = new BaseClass();
        baseClass.SayHello();

        Console.WriteLine("\n* Results from DerivedClass:\n");

        DerivedClass derivedClass = new DerivedClass();
        derivedClass.SayHello();
        derivedClass.SayBye();

        Console.WriteLine("\n* Results from DerivedClass stored as a BaseClass variable:\n");

        BaseClass derivedClassAsBaseClass = new DerivedClass();
        derivedClassAsBaseClass.SayHello();

        // Cannot call this as we only have the interface of a BaseClass
        // derivedClassAsBaseClass.SayBye(); 

        Console.ReadKey();
    }
}

