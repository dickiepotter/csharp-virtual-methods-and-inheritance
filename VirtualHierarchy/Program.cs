using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n* Results from BaseClass:\n");

        BaseClass baseClass = new BaseClass();
        baseClass.SayHello();

        Console.WriteLine("\n* Results from BaseDerivedClass:\n");

        BaseDerivedClass baseDerivedClass = new BaseDerivedClass();
        baseDerivedClass.SayHello();
        baseDerivedClass.SayBye();

        Console.WriteLine("\n* Results from DerivedClassA:\n");

        DerivedClassA derivedClassA = new DerivedClassA();
        derivedClassA.SayHello();
        derivedClassA.SayBye();

        Console.WriteLine("\n* Results from DerivedClassB:\n");

        DerivedClassB derivedClassB = new DerivedClassB();
        derivedClassB.SayHello();
        derivedClassB.SayBye();

        Console.WriteLine("\n* Results from DerivedClassA stored as a BaseClass variable:\n");

        BaseClass derivedClassAAsBaseClass = new DerivedClassA();
        derivedClassAAsBaseClass.SayHello();

        Console.WriteLine("\n* Results from DerivedClassA stored as a BaseDerivedClass variable:\n");

        BaseDerivedClass derivedClassAAsBaseDerivedClass = new DerivedClassA();
        derivedClassAAsBaseDerivedClass.SayHello();
        derivedClassAAsBaseDerivedClass.SayBye();

        Console.WriteLine("\n* Results from DerivedClassB stored as a BaseClass variable:\n");

        BaseClass derivedClassBAsBaseClass = new DerivedClassB();
        derivedClassBAsBaseClass.SayHello();

        Console.ReadKey();
    }
}

