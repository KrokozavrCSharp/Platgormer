using UnityEngine;

public class Attacker : MonoBehaviour
{
    public void Attack(Vector2 position, float attackRadious, int damage)
    {
        Collider2D[] enemyTarget = Physics2D.OverlapCircleAll(position, attackRadious);

        foreach (Collider2D enemy in enemyTarget)
        {
            if (enemy.TryGetComponent(out Enemy target))
            {
                target.TakeDamage(damage);
                Debug.Log("Hit");
            }
        }
    }
}
