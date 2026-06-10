using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class JumpHero : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private float _jumpForce = 100f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }    
}