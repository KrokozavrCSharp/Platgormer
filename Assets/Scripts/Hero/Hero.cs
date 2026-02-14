using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private ChekerGround _chekerGround;
    [SerializeField] private AttackPoint _attackpoint;

    private MoverHero _move;
    private JumperHero _jump;
    private Rotator _rotate;
    private InputService _inputService;
    private CharacterAnimator _characterAnimator;
    private Attacker _attack;
    private Health _healthbar;
    private Rigidbody2D _rigidbody;

    private float _directionX;
    private float _directionY = 0;
    private float _rightRotation = 180f;
    private float _leftRotation = 0f;
    private float _attackRadius = 0.8f;

    private bool _isGround = false;
    private bool _isMoving = false;
    private bool _isAttacked = false;

    private int _damage = 20;
    private int _health = 100;
    private int _zeroValue = 0;

    private void Start()
    {
        _move = GetComponent<MoverHero>();
        _jump = GetComponent<JumperHero>();
        _rotate = GetComponent<Rotator>();
        _inputService = GetComponent<InputService>();
        _characterAnimator = GetComponent<CharacterAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _attack= GetComponent<Attacker>();
        _healthbar = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        if (_inputService.IsWalkPressed() && _isGround)
        {
            _move.Move(_rigidbody, _directionX, _directionY);
            _isMoving = true;
        }
        else if (_inputService.IsWalkPressed() && _isGround == false)
        {
            _move.Move(_rigidbody, _directionX, _directionY);
            _isMoving = false;
        }
        else if (_inputService.IsJumpPressed() && _isGround)
        {
            _jump.Jump(_rigidbody);
        }
        else
        {
            _isMoving = false;
        }
    }

    private void Update()
    {
        _isGround = _chekerGround.GetCheckGround();
        _characterAnimator.PlayRun(_isMoving);
        _directionX = _inputService.GetMovement();
        _characterAnimator.PlayAttack(_isAttacked);

        if (_inputService.GetMovement() > _zeroValue)
            _rotate.Rotate(_leftRotation);

        if (_inputService.GetMovement() < _zeroValue)
            _rotate.Rotate(_rightRotation);

        if (_inputService.IsAttacked())
        {
            _isAttacked = true;
            _attack.Attack(_attackpoint.transform.position, _attackRadius, _damage);
        }
        else
            _isAttacked = false;

        if (_health <= _zeroValue)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
            Destroy(coin.gameObject);

        if (other.TryGetComponent(out Aid aid))
        {
            _health += aid.GetAid();
            Destroy(aid.gameObject);
        }
    }

    public void TakeDamage(int damage) 
    {
        _healthbar.TakeDamage(_health, damage);
    }
}