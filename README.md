# Generics

If you ever worked with Linq, EF or just a Dictionary you've probably already used Generics. The idea of this repo is trying to get you familiarized with some concepts while watching some examples.

# What are 'Generics'?

Don't go crazy, they're just **templates** (of classes, interfaces, methods, etc..) that enhance the reutilization of code and ensure we minimize runtime errors.
These templates can be parametrized and behave the same but with different **types** we opt to pass it.

## When and why were they introduced into .net?

Old .net framework 2.0.
Basically they were meant to **solve** the cast exceptions on runtime due to the unboxing, and, by the way, enhance reusability of code.

## What can be Generic?

- Interfaces
- Classes
- Methods -- great for extension methods --
- Structs
- Delegates -- Actions, Funcs, Predicates --

But not Enums.. technically is possible in a nested Generic but, what's the use?

```csharp ##example
//Console.WriteLine("Fenced code blocks ftw!");
```

## What's different from an abstract class?

The compiler will **never ever** let you instantiate an object from an abstract class, will claim:
> Cannot create an instance of an abstract type or interface '...'

The compiler will let you instantiate an object from a Generic class, it will just shout at you if you dont provide the requested type/s
> Using the generic type '...\<T, ..>' requires n type/s argument/s 
