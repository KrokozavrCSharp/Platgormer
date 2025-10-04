using UnityEngine;

public class TakerDamage : MonoBehaviour
{
    public int TakeDamage(int health,int damage)
    {
        health-=damage;

        return health;
    }
}
