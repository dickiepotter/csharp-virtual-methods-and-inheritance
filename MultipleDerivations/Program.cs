using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n* Results from BaseClass:\n");

        BaseClass baseClass = new BaseClass();
        baseClass.SayHello();

        Console.WriteLine("\n* Results from DerivedClassA:\n");

        DerivedClassA derivedClassA = new DerivedClassA();
        derivedClassA.SayHello();
        derivedClassA.SayBye();

        Console.WriteLine("\n* Results from DerivedClassB:\n");

        DerivedClassB derivedClassB = new DerivedClassB();
        derivedClassB.SayHello();
        derivedClassB.SayBye();

        Console.WriteLine("\n* Results from DerivedClassA stored as a BaseClass variable:\n");

        BaseClass derivedClassAsBaseClass = new DerivedClassA();
        derivedClassAsBaseClass.SayHello();

        Console.WriteLine("\n* Results from DerivedClassB stored in the BaseClass variable which previously held DerivedClassA:\n");

        derivedClassAsBaseClass = new DerivedClassB();
        derivedClassAsBaseClass.SayHello();

        Console.ReadKey();
    }
}

