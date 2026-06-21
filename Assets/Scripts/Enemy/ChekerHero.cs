using UnityEngine;

public class ChekerHero : MonoBehaviour
{
   [SerializeField] private LayerMask _layersMask;

    private bool _canAttack;

    private float _checkRadius = 0.3f;

    public void CheckHero()
    {
        Collider2D[] heroTarget = Physics2D.OverlapCircleAll(transform.position, _checkRadius, _layersMask);

        if (heroTarget.Length > 0)
        {
            _canAttack = true;
        }
        else
        {
            _canAttack = false;
        }
    }

    public bool GetState()
    {
        return _canAttack;
    }
}
