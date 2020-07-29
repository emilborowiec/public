# C# keywords - short reference

> You can use reserved keyword as identifier with @ prefix, for example:
> ```
> class @class
> ```

## Types

## Type and member inheritance-related modifiers

### abstract
- indicates that class or class member must be implemented by derived classes
- abstract class cannot be instantinated
- abstract class can have abstract members
- can be used on classes, methods, properties, indexers, and events

### virtual
- allows class member to be overridden in a derived class
- cannot be used together with `static`, `abstract`, `private`, or `override` modifiers

### new 
- used as a modifier on a method, property, indexer or event in a derived class it signalizes that this derived version is knowingly hiding same-named memeber in the base class

### sealed
- prevents inheritance of class or certain class member
- sometimes makes calling such class faster
- can be used on classes but also individual members
