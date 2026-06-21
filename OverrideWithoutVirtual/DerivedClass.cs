using System;

public class DerivedClass : BaseClass
{
    public void SayBye()
    {
        Console.WriteLine("Goodbye World from DerivedClass.");
    }

    // -------------------------------------------------------------------------
    // This is the whole point of this example (see slide 8 of the presentation).
    //
    // BaseClass.SayHello() is NOT marked 'virtual', so it cannot be overridden.
    // Uncommenting the method below will FAIL to compile with:
    //
    //   CS0506: 'DerivedClass.SayHello()': cannot override inherited member
    //   'BaseClass.SayHello()' because it is not marked virtual, abstract,
    //   or override
    //
    // Compare this with the 'Override' and 'Base' projects, where SayHello()
    // *is* marked virtual and overriding therefore works.
    // -------------------------------------------------------------------------

    // public override void SayHello()
    // {
    //     Console.WriteLine("Hello World from DerivedClass.");
    // }
}
