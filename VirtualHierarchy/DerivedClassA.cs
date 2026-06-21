using System;

public class DerivedClassA : BaseDerivedClass
{
    public override void SayBye()
    {
        Console.WriteLine("Goodbye World from DerivedClassA.");
    }

    public override void SayHello()
    {
        Console.WriteLine("Hello World from DerivedClassA.");
    }
}

