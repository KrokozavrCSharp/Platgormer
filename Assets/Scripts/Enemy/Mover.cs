using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoinys;

    private float _speed = 2f;

    private int _indexpoints = 0;
    private int _rightRotation = 0; 
    private int _leftRotation = 180; 

    private void Update()
    {
        Patrol();

        Rotate();
    }

    private void Patrol()
    {
        if (transform.position.x == _wayPoinys[_indexpoints].position.x)
        {
            _indexpoints = (_indexpoints + 1) % _wayPoinys.Length;
        }

        transform.position = Vector2.MoveTowards(transform.position, _wayPoinys[_indexpoints].position, _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        if((_wayPoinys[_indexpoints].position.x- transform.position.x) > 0) 
        {
            Quaternion rotation = transform.rotation;

            rotation.y = -_rightRotation;

            transform.rotation = rotation;
        }
        else
        {
            Quaternion rotation = transform.rotation;

            rotation.y = -_leftRotation;

            transform.rotation = rotation;
        }
    }
}