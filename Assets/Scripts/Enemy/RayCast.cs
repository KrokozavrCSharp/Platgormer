using UnityEngine;

public class RayCast : MonoBehaviour
{
    private RaycastHit2D _hit;
    private Ray2D _view;

    private bool _isSeing;

    public bool See()
    {
        _view = new Ray2D(transform.position, transform.right);


        _hit = Physics2D.Raycast(transform.position, transform.right, 5f);

        Debug.DrawRay(_view.origin, _view.direction);
        if (_hit.collider!= null && _hit.collider.TryGetComponent(out Hero hero))
        {
            _isSeing = true;
            Debug.Log(_hit.collider.name);
        }
        else
        {
            _isSeing = false;
            Debug.Log("Nothing");
        }

        return _isSeing;
    }
}

 