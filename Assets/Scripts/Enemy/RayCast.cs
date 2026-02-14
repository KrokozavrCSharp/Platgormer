using UnityEngine;

public class RayCast : MonoBehaviour
{
    private RaycastHit2D _hit;
    private Ray2D _view;

    public bool _isSeing;
    public bool _canAttack;
    public float _distance = 5f;

    public bool See()
    {
        _view = new Ray2D(transform.position, transform.right);


        _hit = Physics2D.Raycast(transform.position, transform.right, _distance);

        Debug.DrawRay(_view.origin, _view.direction);
        if (_hit.collider!= null && _hit.collider.TryGetComponent(out Hero hero))
        {
            _isSeing = true;
            Debug.Log(_hit.collider.name);
        }
        else
        {
            _isSeing = false;
            _canAttack = false;
            Debug.Log("Nothing");
        }

        return _isSeing;
    }
}

 