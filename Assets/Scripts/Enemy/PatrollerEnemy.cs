using UnityEngine;

public class PatrollerEnemy : MonoBehaviour
{
    public int GetNextPosition(int index,int countPoints)
    {
        index = ++index % countPoints;
        
        return index;
    }
}