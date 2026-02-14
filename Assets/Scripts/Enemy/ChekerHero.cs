using UnityEngine;

public class ChekerHero : MonoBehaviour
{
    private bool _canAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Hero hero))
        {
            _canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.TryGetComponent(out Hero hero))
        {
            _canAttack = false;
        }
    }

    public bool GetState()
    {
        return _canAttack;
    }
}
