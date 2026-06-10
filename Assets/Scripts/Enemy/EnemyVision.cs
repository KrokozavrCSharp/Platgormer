using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private RaycastHit2D _hit;
    private Ray2D _view;

    public Action<Vector2> SeeHero; 

    public bool _isSeeing;
    public bool _canAttack;
    public float _distance = 15f;

    public bool Search()
    {
        _view = new Ray2D(transform.position, transform.right);

        _hit = Physics2D.Raycast(transform.position, transform.right, _distance);

        Debug.DrawRay(_view.origin, _view.direction);
        if (_hit.collider!= null && _hit.collider.TryGetComponent(out Hero hero))
        {
            _isSeeing = true;
            SeeHero?.Invoke(hero.transform.position);
            Debug.Log(_hit.collider.name);
        }
        else
        {
            _isSeeing = false;
            _canAttack = false;
            Debug.Log("Nothing");
        }

        return _isSeeing;
    }
}

 