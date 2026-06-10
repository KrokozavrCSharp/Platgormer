using UnityEngine;

public class Rotator : MonoBehaviour
{
    private PatrollerEnemy _patroler;

    private float _rightRotation = 0;
    private float _leftRotation = 180;
    private float _zeroValue = 0;

    private Quaternion _targetRightRotation;
    private Quaternion _targetLeftRotation;
   

    private void Awake()
    {
        _targetRightRotation = Quaternion.Euler(_zeroValue, _rightRotation, _zeroValue);
        _targetLeftRotation = Quaternion.Euler(_zeroValue, _leftRotation, _zeroValue); ;

    }

    public void Rotate(Vector2 target)
    {
        if (transform.position.x > target.x)
            LeftRotate();
        else
            RightRotate();
    }

    public void Flip(float direction)
    {
        if (direction > 0)
            RightRotate();
        else
            LeftRotate();
    }

    private void RightRotate()
    {
        if (transform.rotation != _targetRightRotation)
            transform.rotation = _targetRightRotation;
    }

    private void LeftRotate()
    {
        if (transform.rotation != _targetLeftRotation)
            transform.rotation = _targetLeftRotation;
    }
}

