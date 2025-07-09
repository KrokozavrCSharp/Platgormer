using UnityEngine;

public class MoverHero : MonoBehaviour
{
    [SerializeField] private ChekerGround _chekGround;
    private CharacterAnimator _animator;

    private InputService _inputService;

    private float _speed = 100f;

    private bool _isGround = false;
    private bool _isMoving = false;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<CharacterAnimator>();
        _inputService= GetComponent<InputService>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _isGround = _chekGround.GetCheckGround();

        if (_inputService.IsWalkPressed() && _isGround)
        {
            float directionX = _inputService.GetMovement();
            float directionY = 0;

            _isMoving = true;

            _rigidbody.velocity = new Vector2(directionX * _speed * Time.deltaTime, directionY);
        }
        else if (_inputService.IsWalkPressed() && _isGround == false)
        {
            float directionX = _inputService.GetMovement();

            _isMoving = false;

            _rigidbody.velocity = new Vector2(directionX * _speed * Time.deltaTime, _rigidbody.velocity.y);
        }
        else
        {
            _isMoving = false;
        }
        
        _animator.PlayRun(_isMoving);
    }
}