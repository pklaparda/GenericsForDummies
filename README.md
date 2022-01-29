# Generics

If you ever worked with Linq, EF or just a Dictionary you've probably used Generics. The idea of this repo is trying to get you familiarized with some concepts while watching some examples. But first...

# What are 'Generics'?

Don't go crazy, they're just **templates** (of classes, interfaces, methods, etc..) that enhance the reutilization of code and ensure we minimize runtime errors.
These templates can be **parametrized** and behave the same but with different **types** we opt to pass it.
With a generic class we can create real instances with the type we want (unless there's an explicit limitation ;)
```csharp ##example
public class GenericEntity <T> where T: struct {
    public GenericEntity(T id, string description)
    {
	    Id = id;
	    Description = description;
    }
    public T Id { get; set; }
    public string Description { get; set; }
    public override string ToString() {
        return $"This {GetType().Name} is {Description}, identified by {Id} (of type {typeof(T)})";
    }
}
```
So this class is very simple, lets us create any  entity on the fly and select the type for the Id. 
For example:
```csharp
var carEntity = new GenericEntity<int>(123, "the best car ever");
var devEntity = new GenericEntity<double>(15.21, "a weirdly identified developer");
```
Their .ToString() will produce:
- *This generic entity represents the best car ever, identified by 123 (of type System.Int32)*
- *This generic entity represents a weirdly identified developer, identified by 15.21 (of type System.Double)*

However, if I try something like:
```csharp
var notAllowedEntity = new GenericEntity<string>("FX_123", "a not allowed thing for this generic class");
```
We'll see the message "*The type 'string' must be a non-nullable value type in order to use it as parameter 'T' in the generic type or method 'GenericEntity<T>'*" because of the **struct** limitation, and makes sense in this case, I don't want objects as identifiers.

## When and why were they introduced into .net?

Apparently by .net framework 2.0. I dont know if I was born yet.
Basically they were meant to **solve** the <ins>cast exceptions</ins> on runtime due to the <ins>unboxing</ins>, and, by the way, enhance <ins>reusability of code</ins>.

## What can be Generic?

- Interfaces
- Classes
- Methods
- *Structs*
- *Delegates -- Actions, Funcs, Predicates --*

We have some examples of the first three on the repo.

## What's different between a Generic and an Abstract class?
It's like oil and water.
The compiler will **never ever** let you instantiate an object from an abstract class, will claim:
```csharp
public class AbsGenClass<T> { }
var abs = new AbsClass();
```
> Cannot create an instance of an abstract type or interface '...'

The compiler **will** let you instantiate an object from a Generic class, it will just shout at you if you dont provide the requested type/s
```csharp
public class GenClass<T> { }
var gen = new GenClass();
```
> Using the generic type '...\<T, ..>' requires n type/s argument/s 

So you can create a GenClass instance, just need to provide the Type :)

## Advantages
- no runtime cast exceptions
- no performance penalty for boxing/unboxing
- code reusability
