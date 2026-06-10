using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action <GameObject> HealthChanged;

    private float _health = 100;
    private float _maxHealth = 100;
    private float _zeroValue = 0;

    public void TakeDamage(float damage)
    {
        if (damage>0)
            _health -= damage;

        if ( _health == 0 )
            HealthChanged?.Invoke(gameObject);
    }

    public void Regeneration(Aid aid)
    {
        float treatment = aid.GetAid();

        if (treatment > _zeroValue && _health < _maxHealth)
        {
            _health += treatment;

            _health = Mathf.Clamp(_health, _zeroValue, _maxHealth);
        }
    }
}

  
