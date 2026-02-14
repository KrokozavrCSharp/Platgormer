using UnityEngine;

public class Health : MonoBehaviour
{
    public int TakeDamage(int health,int damage)
    {
        health -= damage;

        return health;
    }

    public int Regeneration(int health, int treatment)
    {
        health += treatment;

        return health;
    }
}

  
