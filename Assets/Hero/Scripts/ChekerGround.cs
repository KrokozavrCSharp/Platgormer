using UnityEngine;

public class ChekerGround : MonoBehaviour
{
    private bool _isGround;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Ground>(out Ground ground)  || other.TryGetComponent<Platforma>(out Platforma platforma))
            _isGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Ground>(out Ground ground) || other.TryGetComponent<Platforma>(out Platforma platforma))
            _isGround = false;
    }

    public bool GetCheckGround()
    {
        return _isGround;
    }
}
