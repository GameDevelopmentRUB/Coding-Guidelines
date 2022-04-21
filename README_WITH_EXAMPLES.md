# Coding Guidelines and Best Practices

## Guidelines
-> Points may be deducted for non-compliance

### Naming Conventions

* Class and method names in **PascalCase** 
```cs
public class ExampleClass : MonoBehaviour 
{ 
    void DoSomething() 
    { 
    } 
}
```

* Constants in **PascalCase** or **UPPER_CASE**
```cs
const int START_HEALTH = 10;
```

* Everything else in **camelCase**
```cs
bool isRunning;
```

* No **numbers or special characters** in identifiers (also no underscores)
```cs
int player1_health; // Wrong
int firstPlayerHealth; // Right
```

* Identifiers should be chosen **expressive and self-documenting**: Do not use **abbreviations** or type prefixes
```cs
bool cPlDSth; // Wrong
bool canPlayerDoSomething; // Right
```

* Boolean identifiers should start with **is, has**, or something similar
```cs
bool defending; // Wrong
bool isDefending; // Right
```

* **Correct spelling** should be used throughout the code

### Coding style
* Code must be **formatted correctly**, curly braces start on the **next line** (Allman style)
```cs
// Wrong
if(isDefending) {
BlockAttack(   )        ;
}else { return;}

// Right
if (isDefending)
{
    BlockAttack();
}
else
{
    return;
}
```

* No **commented out "zombie code"** may be left in the scripts
```cs
void DoSomething()
{
    // We did this before but left it in just in case
    // DoSomethingUnnecessaryAndObsolete();

    DoTheCorrectThing();
}
```

* Instead of concatenating strings and other variables, **string interpolation** should be used
```cs
Debug.Log("The player with name " + playerName + " has " + health + " health left"); // Wrong
Debug.Log($"The player with name {playerName} has {health} health left"); // Right
```

### Architecture
* **No getter and setter** methods for single class variables should be implemented as in Java
```cs
// Do not do this

int someNumber;

int GetSomeNumber()
{
    return someNumber;
}

void SetSomeNumber(int value)
{
    someNumber = value;
}
```

* The **behavior / logic** of the objects must be implemented **in MonoBehaviour** classes, **Non-MonoBehaviour** classes may only be used **as data containers**
```cs
class PlayerStats
{
    public int health;

    public void Die() // Wrong
    {
        health = 0;
        // ...
    }
}

public class Player : MonoBehaviour
{
    PlayerStats stats;

    void DoSomething()
    {
        // ...
        stats.Die(); // Wrong
    }

    void Die() // Right
    {
        stats.health = 0;
    }
}
```

* Code that occurs **more than once** must be outsourced to methods
```cs
// Wrong
void DoSomething()
{
    // ...
    Debug.Log($"Health: {health}");
}

void DoSomethingElse()
{
    // ...
    Debug.Log($"Health: {health}");
}

// Right
void DoSomething()
{
    // ...
    PrintHealth();
}

void DoSomethingElse()
{
    // ...
    PrintHealth();
}

void PrintHealth()
{
    Debug.Log($"Health: {health}");
}
```

* Strings, numbers and other **constant values** should be outsourced to (constant) **class variables** instead of being hardcoded in multiple places in the code
```cs
const int START_HEALTH = 10;


// Wrong
void Restart()
{
    health = 10;
}

// Right
void Restart()
{
    health = START_HEALTH;
}
```

* Complex logical expressions must be split into **auxiliary variables**
```cs
// Wrong
if (isSomething || !isSomethingElse && someValue > 10 || someValue < 5)
{
    // ...
}

// Right
bool firstCondition = isSomething || !isSomethingElse;
bool secondCondition = someValue > 10 || someValue < 5;

if (firstCondition && secondCondition) 
{ 
    // ... 
}
```

* if-statements must not be **nested many times**, instead outer if-statements should be **inverted** and converted to **termination conditions**
```cs
// Wrong
if (someCondition)
{
    if (someOtherCondition)
    {
        if (health > 5)
        {
            // ...
        }
    }
}

// Right
if (!someCondition) return;
if (!someOtherCondition) return;

if (health > 5)
{
    // ...
}
```

## Best Practices
-> Serve as orientation, but do not have to be implemented

* **Initial values** of class variables can be **assigned directly** when declaring them
```cs
// Right
int health = START_HEALTH;

// Wrong
void Start()
{
    health = START_HEALTH;
}
```

* **Default values** for variables do not have to be **assigned explicitly**
```cs
// Wrong
bool isSomething = false;
int someNumber = 0;

// Right
bool isSomething;
int someNumber;
```

* **this** must only be used in case of name conflicts
```cs
int health;

void DoSomething()
{
    // Wrong
    Debug.Log(this.health);

    // Right
    Debug.Log(health);
}
```

* only constants should be declared with **const**
```cs
// Wrong
const float SPEED = 5.5f;
float pi = 3.14f;

// Right
const float PI = 3.14f;

[SerializeField]
float speed = 5.5f;
```

* Use **enums** instead of strings or ints for **classification**
```cs
// Wrong
string state;

void DoSomething()
{
    switch (state)
    {
        case "alive":
            break;
        case "dead":
            break;
    }
}

// Right
enum State
{
    Alive,
    Dead
}

State state;

void DoSomething()
{
    switch (state)
    {
        case State.Alive:
            break;
        case State.Dead:
            break;
    }
}
```

* **private** does not have to be explicitly assigned
```cs
// Wrong
private int someNumber;

private void DoSomething() { }

// Right
int someNumber;
void DoSomething() { }
```

* Use **compound assignments*** if possible
```cs
void Heal()
{
    // Wrong
    health = health + 2;

    // Right
    health += 2;
}

```

* If getter or setter methods are needed use **C# properties** instead
```cs
int someNumber;
int SomeNumber
{
    get
    {
        return someNumber;
    }
    set
    {
        someNumber = value;
        SomeSideEffect();
    }
}
```

* Do not use **redundant logic expressions** like isRunning == true
```cs
// Wrong
if (isSomething == true) { }

// Right
if (isSomething) { }
```

* Use **switch** expressions or statements instead of if statements for case distinctions
```cs
// Wrong
if (state == State.Alive)
{

}
else if (state == State.Dead)
{

}

// Right
switch (state)
{
    case State.Alive:
        break;
    case State.Dead:
        break;
}
```

* **Avoid comments**, instead write self-documenting code and XML documentation
```cs
// Wrong

// This is a small heal
void FirstHeal()
{
    // Add two to health
    health += 2
}

// This is a large heal
void SecondHeal()
{
    // Add five to health
    health += 5;
}

// Right

void DoSomething()
{
    Heal(smallHealthBonus);
    Heal(largeHealthBonus);
}

void Heal(int healthBonus)
{
    health += healthBonus;
}
```

* **Use empty lines** to divide code into logically related sections
```cs
// Wrong
void Restart()
{
    health = START_HEALTH;
    ui.Refresh();
    SpawnEnemy();
    particleSystemManager.Restart();
    SpawnEnemy();
    healthBonus = START_HEALTH_BONUS;
    if (level == 3)
    {
        SpawnBoss();
    }
}

// Right
void Restart()
{
    health = START_HEALTH;
    healthBonus = START_HEALTH_BONUS;

    SpawnEnemy();
    SpawnEnemy();

    if (level == 3)
    {
        SpawnBoss();
    }

    ui.Refresh();
    particleSystemManager.Restart();
}
```

* Declare each variable on a **separate line**
```cs
// Wrong
bool isSomething, isSomethingElse;

//Right
bool isSomething;
bool isSomethingElse;
```

* Do not use **System.Reflection** or **UnityEditor** in runtime code
```cs
// Do not do this
using UnityEditor;
using System.Reflection;
```
