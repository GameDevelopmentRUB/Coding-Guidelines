using UnityEngine;

public class Player : MonoBehaviour // Use MonoBehaviour classes
{
    const int START_HEALTH = 10; // Use constants or class variables for constant values

    enum PlayerState // Use enums for classifications
    {
        Alive,
        Dead
    }

    public int health = START_HEALTH; // Assign initial values directly
    public bool isDefending; // Use is or has for boolean identifiers

    PlayerState state; // Do not explicitly use private

    void Update()
    {
        if (isComputersTurn) return;
        // ...
    }

    void OnEnemyAttack(int damage)
    {
        if (isGameRunning == true) // Redundant!
        {
            if ((!isDefending || isCharged) && !isInvincible && damage < health) // Too complicated!
            {
                // ...
            }
        }
        
        // Simplify this expression! Remove the old code afterwards!

        if (!isGameRunning) return; // Termination condition
        if (isInvincible) return; // Termination condition

        bool isIneffective = isDefending && !isCharged; // Auxiliary variable

        if (isIneffective) return; // Termination condition

        bool hasSurvived = damage < health; // Auxiliary variable
        
        if (hasSurvived)
        {
            health -= damage; // Use compound assignments
            PrintHealth(health);
            // ...
        }
    }

    void OnRoundOver()
    {
        switch (state) // Use switch for case distinctions
        {
            case PlayerState.Alive:
                // ...
                break;
            case PlayerState.Dead:
                // ...
                break;
        }
    }

    // Make code reusable
    void PrintHealth(int health)
    {
        Debug.Log($"Health: {health}"); // Use string interpolation
    }
}