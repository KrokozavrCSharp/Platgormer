using UnityEngine;

public class ChekerGround : MonoBehaviour
{
    private bool _isGround;

    private int _inEarthCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ground ground)  || other.TryGetComponent(out Platform platforma)) 
        {
            ++_inEarthCount;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ground ground) || other.TryGetComponent(out Platform platforma)) 
        {
            --_inEarthCount;
        }
    }

    public bool GetCheckGround()
    {
        if(_inEarthCount>0)
            _isGround=true;
        else
            _isGround=false;

        return _isGround;
    }
}
