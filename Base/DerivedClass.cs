using System;

public class DerivedClass : BaseClass
{
    public override void SayHello()
    {
        base.SayHello();
        Console.WriteLine("- And Hello World from DerivedClass.");
    }

    public void SayBye()
    {
        Console.WriteLine("Goodbye World from DerivedClass.");
    }
}
