using System;

public class DerivedClass : BaseClass
{
    public override void SayHello()
    {
        Console.WriteLine("Hello World from DerivedClass.");
    }

    public void SayBye()
    {
        Console.WriteLine("Goodbye World from DerivedClass.");
    }
}
