using System;

public class DerivedClassA : BaseClass
{
    public override void SayHello()
    {
        Console.WriteLine("Hello World from DerivedClassA.");
    }

    public void SayBye()
    {
        Console.WriteLine("Goodbye World from DerivedClassA.");
    }
}
