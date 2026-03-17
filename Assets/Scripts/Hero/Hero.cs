using UnityEngine;

public class Hero : MonoBehaviour, IAttacker, IDamageable
{
    [SerializeField] private ChekerGround _chekerGround;
    [SerializeField] private AttackPoint _attackpoint;

    private MoverHero _move;
    private JumperHero _jump;
    private Rotator _rotate;
    private InputService _inputService;
    private CharacterAnimator _characterAnimator;
    private Health _healthbar;
    private Collector _collector;

    private float _directionX;
    private float _directionY = 0;
    private float _rightRotation = 180f;
    private float _leftRotation = 0f;
    private float _attackRadius = 0.8f;

    private bool _isGround = false;
    private bool _isMoving = false;
    private bool _isAttacked = false;

    private int _damage = 20;
    private int _zeroValue = 0;

    private void Awake()
    {
        _move = GetComponent<MoverHero>();
        _jump = GetComponent<JumperHero>();
        _rotate = GetComponent<Rotator>();
        _inputService = GetComponent<InputService>();
        _characterAnimator = GetComponent<CharacterAnimator>();
        _healthbar = GetComponent<Health>();
        _collector= GetComponent<Collector>();
    }

    private void FixedUpdate()
    {
        if (_inputService.IsWalkPressed && _isGround)
        {
            _move.Move(_directionX, _directionY);
            _isMoving = true;
        }
        else if (_inputService.IsWalkPressed && _isGround == false)
        {
            _move.Move(_directionX, _directionY);
            _isMoving = false;
        }
        else if (_inputService.IsJumpPressed && _isGround)
        {
            _jump.Jump();
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
            Attack();
        }
        else
            _isAttacked = false;
    }

    private void OnEnable()
    {
        _collector.TakeAid += _healthbar.Regeneration;
    }

    private void OnDisable()
    {
        _collector.TakeAid -= _healthbar.Regeneration;
    }

    public void Attack()
    {
        Collider2D[] enemyTarget = Physics2D.OverlapCircleAll(_attackpoint.transform.position, _attackRadius);

        foreach (Collider2D enemy in enemyTarget)
        {
            if (enemy.TryGetComponent(out Enemy target))
            {
                target.TakeDamage(_damage);
                Debug.Log("Hit");
            }
        }
    }

    public void TakeDamage(int damage) 
    {
        _healthbar.TakeDamage(damage);
    }
}