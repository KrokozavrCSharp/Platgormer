using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animations _animator;

    private float _speed = 100f;
    private float _jumpForce = 200f;
    private float _rightRotation = 180f;
    private float _leftRotation = 0f;


    private bool _isGround = false;
    private bool _isMoving = false;
    private bool _isJumping = false;


    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animations>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        Jump();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGround = false;
    }

    private void Move()
    {
        if (Input.GetButton("Horizontal") && _isGround)
        {
            float directionX = Input.GetAxisRaw("Horizontal");
            float directionY = 0;

            _isMoving = true;

            _rigidbody.velocity = new Vector2(directionX * _speed * Time.deltaTime, directionY);
        }
        else
        {
            Debug.Log("Bye");
            _isMoving = false;
        }

        _animator.PlayRun(_isMoving);
    }

    private void Jump()
    {
        if (Input.GetButton("Jump") && _isGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }


    private void Rotate()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            Quaternion rotation = transform.rotation;

            rotation.y = _leftRotation;

            transform.rotation = rotation;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            Quaternion rotation = transform.rotation;

            rotation.y = -_rightRotation;

            transform.rotation = rotation;
        }
    }
}

