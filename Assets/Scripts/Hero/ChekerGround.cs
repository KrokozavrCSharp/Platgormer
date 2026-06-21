using UnityEngine;

public class ChekerGround : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    private bool _isGround;

    private float _checkRadious = 0.3f;

    public bool GetCheckGround()
    {
        return _isGround;
    }

    public void CheckGround()
    {
        Collider2D[] groundTarget = Physics2D.OverlapCircleAll(transform.position, _checkRadious, _groundLayer);

        if (groundTarget.Length > 0)
            _isGround = true;
        else
            _isGround = false;
    }
}
