using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Agent : MonoBehaviour
{
    public Vector2Int position;
    public int energy;
    public int energyPots;
    public bool hasMapKnowledge;

    public Agent(Vector2Int startPosition, int startEnergy, int startEnergyPots)
    {
        position = startPosition;
        energy = startEnergy;
        energyPots = startEnergyPots;
        hasMapKnowledge = false;
    }

    public void Move(Vector2Int direction)
    {
        if (energy > 0)
        {
            position += direction;
            energy--;
            Debug.Log($"Agent moved to {position}. Energy left: {energy}");
        }
        else
        {
            Debug.Log("Not enough energy to move!");
        }
    }

    public void CollectEnergyPot()
    {
        energyPots++;
        energy--;
        Debug.Log($"Agent collected an energy pot. Energy pots: {energyPots}, Energy left: {energy}");
    }

    public bool BuyMapKnowledge(Agent otherAgent)
    {
        if (IsAdjacent(otherAgent) && otherAgent.hasMapKnowledge)
        {
            otherAgent.energy--;
            this.hasMapKnowledge = true;
            Debug.Log("Map knowledge bought from another agent.");
            return true;
        }
        Debug.Log("Transaction failed: No map knowledge or not adjacent.");
        return false;
    }

    public bool BuyEnergyPot(Agent otherAgent)
    {
        if (IsAdjacent(otherAgent) && otherAgent.energyPots > 0)
        {
            otherAgent.energyPots--;
            this.energyPots++;
            this.energy--;
            Debug.Log("Energy pot bought from another agent.");
            return true;
        }
        Debug.Log("Transaction failed: No energy pots or not adjacent.");
        return false;
    }

    private bool IsAdjacent(Agent otherAgent)
    {
        return Vector2Int.Distance(this.position, otherAgent.position) == 1;
    }
}
