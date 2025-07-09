using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    private float _speed = 2f;

    private Rigidbody2D _rigidbody;

    public void Start()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 position)
    {
        _rigidbody.position = Vector2.MoveTowards(transform.position, position, _speed * Time.deltaTime);
    }
}
