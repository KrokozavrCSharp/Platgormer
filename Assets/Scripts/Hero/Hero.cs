using UnityEngine;

[RequireComponent (typeof (MoverHero),typeof (JumpHero), typeof (Rotator))]
[RequireComponent (typeof (InputService),typeof (CharacterAnimator), typeof (Health))]
[RequireComponent (typeof (Collector),typeof (PlayerDeathHandler), typeof(Wallet))]

public class Hero : MonoBehaviour, IAttacker, IDamageable
{
    [SerializeField] private ChekerGround _chekerGround;
    [SerializeField] private AttackPoint _attackpoint;

    private MoverHero _move;
    private JumpHero _jump;
    private Rotator _rotate;
    private InputService _inputService;
    private CharacterAnimator _characterAnimator;
    private Health _healthbar;
    private Collector _collector;
    private PlayerDeathHandler _playerDeathHandler;
    private Wallet _wallet;

    private float _directionX;
    private float _directionY = 0;
    private float _attackRadius = 0.8f;

    private bool _isGround = false;
    private bool _isMoving = false;
    private bool _isAttacked = false;

    private int _damage = 20;
    private int _zeroValue = 0;

    private void Awake()
    {
        _move = GetComponent<MoverHero>();
        _jump = GetComponent<JumpHero>();
        _rotate = GetComponent<Rotator>();
        _inputService = GetComponent<InputService>();
        _characterAnimator = GetComponent<CharacterAnimator>();
        _healthbar = GetComponent<Health>();
        _collector = GetComponent<Collector>();
        _playerDeathHandler=GetComponent<PlayerDeathHandler>();
        _wallet= GetComponent<Wallet>();
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

        if (_inputService.GetMovement() != 0)
        {
         _rotate.Flip(_inputService.GetMovement());
        }

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
        _healthbar.HealthChanged += _playerDeathHandler.Death;
        _collector.TakeCoin += _wallet.MoneyIncrease;
    }

    private void OnDisable()
    {
        _collector.TakeAid -= _healthbar.Regeneration;
        _healthbar.HealthChanged -= _playerDeathHandler.Death;
        _collector.TakeCoin -= _wallet.MoneyIncrease;
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

    public void TakeDamage(float damage) 
    {
        _healthbar.TakeDamage(damage);
    }
}