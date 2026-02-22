using UnityEngine;

public class Health : MonoBehaviour
{
    private int _health = 100;
    private int _maxHealth = 100;
    private int _zeroValue = 0;

    public void TakeDamage(int damage)
    {
        if (damage>0)
            _health -= damage;

        if ( _health < 0 )
            Destroy(gameObject);
    }

    public void Regeneration( int treatment)
    {
        if(treatment > _zeroValue && _health < _maxHealth)
        {
            _health += treatment;
            if(_health> _maxHealth)
                _health = _maxHealth;
        }
    }
}

  
