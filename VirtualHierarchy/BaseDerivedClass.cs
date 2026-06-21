using System;

public class BaseDerivedClass : BaseClass
{
    public virtual void SayBye()
    {
        Console.WriteLine("Goodbye World from BaseDerivedClass.");
    }
}
