using System;

public class DerivedClassB : BaseClass
{
    public override void SayHello()
    {
        Console.WriteLine("Hello World from DerivedClassB.");
    }

    public void SayBye()
    {
        Console.WriteLine("Goodbye World from DerivedClassB.");
    }
}
