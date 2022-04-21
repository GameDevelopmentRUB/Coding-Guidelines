# Coding Guidelines and Best Practices
-> For examples see [README_WITH_EXAMPLES](README_WITH_EXAMPLES.md) or [ExampleCode.cs](ExampleCode.cs)

## Guidelines
-> Points may be deducted for non-compliance

### Naming Conventions

* Class and method names in **PascalCase**
* Constants in **PascalCase** or **UPPER_CASE**
* Everything else in **camelCase**
* No **numbers or special characters** in identifiers (also no underscores)
* Identifiers should be chosen **expressive and self-documenting**: Do not use **abbreviations** or type prefixes
* Boolean identifiers should start with **is, has**, or something similar
* **Correct spelling** should be used throughout the code

### Coding style
* Code must be **formatted correctly**, curly braces start on the **next line** (Allman style)
* No **commented out "zombie code"** may be left in the scripts
* Instead of concatenating strings and other variables, **string interpolation** should be used

### Architecture
* **No getter and setter** methods for single class variables should be implemented as in Java
* The **behavior / logic** of the objects must be implemented **in MonoBehaviour** classes, **Non-MonoBehaviour** classes may only be used **as data containers**
* Code that occurs **more than once** must be outsourced to methods
* Strings, numbers and other **constant values** should be outsourced to (constant) **class variables** instead of being hardcoded in multiple places in the code
* Complex logical expressions must be split into **auxiliary variables**
* if-statements must not be **nested many times**, instead outer if-statements should be **inverted** and converted to **termination conditions**

## Best Practices
-> Serve as orientation, but do not have to be implemented

* **Initial values** of class variables can be **assigned directly** when declaring them
* **Default values** for variables do not have to be **assigned explicitly**
* **this** must only be used in case of name conflicts
* constants should be declared with **const**
* Use **enums** instead of strings or ints for **classification**
* **private** does not have to be explicitly assigned
* Use **compound assignments** if possible
* If getter or setter methods are needed use **C# properties** instead
* Do not use **redundant logic expressions** like isRunning == true
* Use **switch** expressions or statements instead of if statements for case distinctions
* **Avoid comments**, instead write self-documenting code and XML documentation
* **Use empty lines** to divide code into logically related sections
* Declare each variable on a **separate line**
* Do not use **System.Reflection** or **UnityEditor** in runtime code
