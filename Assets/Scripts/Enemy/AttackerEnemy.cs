using UnityEngine;

public class AttackerEnemy : MonoBehaviour
{
    [SerializeField] private AttackPoint _attackpoint;

    private float _attackRadius = 0.8f;

    private int _damage = 20;

    public void Attack()
    {
        Collider2D[] enemyTarget = Physics2D.OverlapCircleAll(_attackpoint.transform.position, _attackRadius);

        foreach (Collider2D enemy in enemyTarget)
        {
            if (enemy.TryGetComponent(out Hero target))
            {
                target.TakeDamage(_damage);
                Debug.Log("Hit");
            }
        }
    }
}
