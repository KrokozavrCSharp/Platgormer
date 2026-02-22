using UnityEngine;

public class MoverHero : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private float _speed = 100f;

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
    }

    public void Move(float directionX,float directionY)
    {
        _rigidbody.velocity = new Vector2(directionX * _speed * Time.fixedDeltaTime, directionY);
    }
}