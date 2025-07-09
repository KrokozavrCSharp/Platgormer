using UnityEngine;

public class RotatorHero : MonoBehaviour
{
    private InputService _inputService;
    private float _rightRotation = 180f;
    private float _leftRotation = 0f;

    private void Start()
    {
        _inputService = GetComponent<InputService>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_inputService.GetMovement() > 0)
        {
            Quaternion rotation = transform.rotation;

            rotation.y = _leftRotation;

            transform.rotation = rotation;
        }

        if (_inputService.GetMovement() < 0)
        {
            Quaternion rotation = transform.rotation;

            rotation.y = -_rightRotation;

            transform.rotation = rotation;
        }
    }
}
