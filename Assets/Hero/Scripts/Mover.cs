using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ChekerGround _chekGround;
    private Animations _animator;

    private float _speed = 100f;
    private float _jumpForce = 100f;
    private float _rightRotation = 180f;
    private float _leftRotation = 0f;

    private bool _isGround = false;
    private bool _isMoving = false;

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
        _isGround = _chekGround.GetCheckGround();

        if (Input.GetButton("Horizontal") && _isGround)
        {
            float directionX = Input.GetAxisRaw("Horizontal");
            float directionY = 0;

            _isMoving = true;

            _rigidbody.velocity = new Vector2(directionX * _speed * Time.deltaTime, directionY);
        }
        else if (Input.GetButton("Horizontal") && _isGround == false)
        {
            float directionX = Input.GetAxisRaw("Horizontal");

            _isMoving = false;

            _rigidbody.velocity = new Vector2(directionX * _speed * Time.deltaTime, _rigidbody.velocity.y);
        }
        else
        {
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