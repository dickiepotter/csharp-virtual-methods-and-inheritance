# Virtual Methods and Inheritance — a C# Tutorial

A small, hands-on tutorial that explains **inheritance**, **method overriding**, and
**virtual methods** in C#. It was originally written and delivered as an internal
training session (with the accompanying PowerPoint, included in this repository)
around 2009, and has been modernised to build and run on current .NET.

Each concept has its own tiny console project so you can read the code, run it, and
see exactly what gets printed — and, just as importantly, *why*.

> The original slide deck is included as
> [`Virtual Methods and Inheritance.pptx`](./Virtual%20Methods%20and%20Inheritance.pptx)
> (and a `.pps` slideshow version). This README reproduces its content so everything
> is readable directly on GitHub.

---

## What you'll learn

By the end of this tutorial you should understand:

- **Simple inheritance** — how a class inherits members from a base class.
- **How to override inherited methods** — replacing a base method in a derived class.
- **How to control overriding using `virtual` methods** — and what happens when a
  method *isn't* marked `virtual`.

---

## Prerequisites & how to run

You need the [.NET SDK](https://dotnet.microsoft.com/download) (8.0 or later).

```bash
# Build everything
dotnet build Inheritance.sln

# Run any single example (replace with the project name)
dotnet run --project Override
```

The projects are interactive console apps — each ends with `Console.ReadKey()` and waits
for a key press before closing, so run them from a terminal.

> **Originally** these were Visual Studio 2008 / .NET Framework 3.5 projects. They have
> been converted to SDK-style projects targeting `net8.0`. **The lesson code itself is
> unchanged** — only the project plumbing was modernised so the examples run on any OS.

---

## The projects at a glance

| Project | Concept | Key point |
|---|---|---|
| [`Inheritance`](./Inheritance) | Simple inheritance | A derived class gains the base class's members. |
| [`OverrideWithoutVirtual`](./OverrideWithoutVirtual) | Why `virtual` matters | Trying to `override` a non-`virtual` method **fails to compile**. |
| [`Override`](./Override) | Overriding a `virtual` method | The derived method runs even through a base-class reference (polymorphism). |
| [`Base`](./Base) | The `base` keyword | An override calls the base implementation with `base.SayHello()`. |
| [`MultipleDerivations`](./MultipleDerivations) | Many classes, one base | Several classes derive from the same base and each overrides differently. |
| [`VirtualHierarchy`](./VirtualHierarchy) | Multi-level hierarchies | Overrides flow through several layers of inheritance. |
| [`Abstract`](./Abstract) | Abstract classes | A base may declare a method with no body; it cannot be instantiated. |

---

## 1. Inheritance

> Classes may *inherit* members from another class.

**Terminology**

- A class inheriting members is **derived** from a **base class**.
- The class providing members is the **base class** of the derived class.
- A derived class may be referred to in terms of its base class.
- A class may inherit from **one** base class.
- The base class may itself be a derived class.
- Many classes may derive from the same base class.

```csharp
public class BaseClass
{
    public void SayHello()
    {
        Console.WriteLine("Hello World from BaseClass.");
    }
}

public class DerivedClass : BaseClass
{
    public void SayBye()
    {
        Console.WriteLine("Goodbye World from DerivedClass.");
    }
}
```

`DerivedClass` now provides **two** methods: the inherited `SayHello()` and its own
`SayBye()`.

```csharp
BaseClass baseClass = new BaseClass();
baseClass.SayHello();
// -> Hello World from BaseClass.

DerivedClass derivedClass = new DerivedClass();
derivedClass.SayHello();   // inherited
derivedClass.SayBye();     // its own
// -> Hello World from BaseClass.
// -> Goodbye World from DerivedClass.

BaseClass derivedClassAsBaseClass = new DerivedClass();
derivedClassAsBaseClass.SayHello();
// -> Hello World from BaseClass.
```

*(See the [`Inheritance`](./Inheritance) project.)*

---

## 2. Overriding methods

> Inherited methods may be replaced (**overridden**).

- Use the **`override`** keyword in C#.
- When you refer to a derived object **through its base class**, the *overridden*
  method in the derived class is the one that runs.
  (This is the opposite of the `new` keyword in a method signature, which *hides*
  rather than overrides.)
- **Only `virtual` or `abstract` methods can be overridden.**
- A method can be re-overridden in each class that inherits it.

### You cannot override a method that isn't `virtual`

```csharp
public class BaseClass
{
    public void SayHello()   // not virtual!
    {
        Console.WriteLine("Hello World from BaseClass.");
    }
}

public class DerivedClass : BaseClass
{
    public override void SayHello()   // <-- compiler error
    {
        Console.WriteLine("Hello World from DerivedClass.");
    }
}
```

This **does not compile**:

```
'DerivedClass.SayHello()': cannot override inherited member
'BaseClass.SayHello()' because it is not marked virtual, abstract, or override
```

*(The [`OverrideWithoutVirtual`](./OverrideWithoutVirtual) project demonstrates this.
The illegal override is kept in the source as a clearly-marked comment so the project
still builds — uncomment it to reproduce the compiler error for yourself.)*

---

## 3. Virtual methods

> `virtual` identifies methods which **may** be overridden.

- Indicated with the **`virtual`** keyword.
- It's a safety feature that not every object-oriented language has (Java, for example,
  makes methods overridable by default).
  - **Advantage:** makes it clear where overriding is intended and prevents
    inappropriate overrides.
  - **Drawback:** you have to decide, for every method, whether it should allow
    overrides.
- A method is declared `virtual` **once**, before its first override. Overridden
  definitions can themselves be overridden further down the hierarchy.

```csharp
public class BaseClass
{
    public virtual void SayHello()
    {
        Console.WriteLine("Hello World from BaseClass.");
    }
}

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
```

Now compare the output with the plain-inheritance example. The crucial line is the last
one — accessing the derived object **through a base-class variable** still calls the
**derived** method:

```csharp
BaseClass baseClass = new BaseClass();
baseClass.SayHello();
// -> Hello World from BaseClass.

DerivedClass derivedClass = new DerivedClass();
derivedClass.SayHello();
derivedClass.SayBye();
// -> Hello World from DerivedClass.
// -> Goodbye World from DerivedClass.

BaseClass derivedClassAsBaseClass = new DerivedClass();
derivedClassAsBaseClass.SayHello();
// -> Hello World from DerivedClass.   <-- the override wins
```

*(See the [`Override`](./Override) project.)*

### The `base` keyword

An override can still call the implementation it replaced, using `base`:

```csharp
public override void SayHello()
{
    base.SayHello();   // run BaseClass.SayHello() first
    Console.WriteLine("- And Hello World from DerivedClass.");
}
```

*(See the [`Base`](./Base) project.)*

---

## 4. A worked example — a small hierarchy

```csharp
public class BaseClass
{
    public virtual void SayHello()
    {
        Console.WriteLine("Hello World from BaseClass.");
    }
}

public class BaseDerivedClass : BaseClass
{
    public virtual void SayBye()
    {
        Console.WriteLine("Goodbye World from BaseDerivedClass.");
    }
}

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

public class DerivedClassB : BaseClass
{
    public void SayBye()
    {
        Console.WriteLine("Goodbye World from DerivedClassB.");
    }
}
```

### Questions

What would be printed to the console for each of the following?

```csharp
DerivedClassA myClass = new DerivedClassA();
myClass.SayHello();

DerivedClassB myClass = new DerivedClassB();
myClass.SayHello();

BaseClass myClass = new DerivedClassA();
myClass.SayHello();

BaseClass myClass = new DerivedClassA();
myClass.SayBye();
```

### Answers

1. `Hello World from DerivedClassA.` — `DerivedClassA` overrides `SayHello()`.
2. `Hello World from BaseClass.` — `DerivedClassB` does **not** override `SayHello()`,
   so the inherited version runs.
3. `Hello World from DerivedClassA.` — the override is called even through a
   `BaseClass` reference, because `SayHello()` is `virtual`.
4. **Nothing** — `BaseClass` does not expose a `SayBye()` method, so this last line
   would not even compile. (`SayBye()` lives further down the hierarchy.)

*(See the [`VirtualHierarchy`](./VirtualHierarchy) project, which exercises every one of
these cases, and [`MultipleDerivations`](./MultipleDerivations) for several siblings
sharing one base class.)*

---

## 5. Abstract classes

A base class can declare a method with **no implementation** at all using `abstract`.
An abstract class cannot be instantiated directly — only its concrete derived classes
can be created.

```csharp
public abstract class BaseClass
{
    public abstract void SayHello();   // no body
}

public class DerivedClass : BaseClass
{
    public override void SayHello()
    {
        Console.WriteLine("Hello World from DerivedClass.");
    }
}
```

```csharp
// BaseClass baseClass = new BaseClass();   // compiler error: cannot create an
//                                          // instance of the abstract type
BaseClass derivedClassAsBaseClass = new DerivedClass();
derivedClassAsBaseClass.SayHello();
// -> Hello World from DerivedClass.
```

*(See the [`Abstract`](./Abstract) project.)*

---

## Exercise to try

> Describe how virtual methods and inheritance could be used to derive a **`Cube`** class
> from a **`Square`** class, where both provide a `GetSurfaceArea()` method.
>
> *Tip: the surface area of a cube is six times the area of one of its square faces.*

---

## Further reading

- Referring to a base class using the `base` keyword. *(shown in the `Base` project)*
- Method hiding using the `new` keyword (different from overriding).
- How to override **properties** as well as methods.
- Abstract classes and members. *(shown in the `Abstract` project)*

---

## A note on history

This material dates from around 2009 and originally targeted C# 3.0 on .NET Framework 3.5
in Visual Studio 2008. The concepts — `virtual`, `override`, `abstract`, and the `base`
keyword — are unchanged in modern C#, which is why the original lesson code compiles and
runs as-is on .NET 8. Newer language features (such as top-level statements or
file-scoped namespaces) are intentionally avoided here so the focus stays on inheritance.
