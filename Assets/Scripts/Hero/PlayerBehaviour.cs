using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool _isDetected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Hero hero))
            _isDetected=true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Hero hero))
            _isDetected = false;
    }

    public bool GetState()
    {
        return _isDetected;
    }
}

