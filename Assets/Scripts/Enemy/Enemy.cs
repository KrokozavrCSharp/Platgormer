using UnityEngine;

[RequireComponent(typeof(MoverEnemy), typeof(PatrollerEnemy), typeof(Rotator))]
[RequireComponent(typeof(Rigidbody2D), typeof(Follower))]
[RequireComponent(typeof(CharacterAnimator), typeof(ChekerHero), typeof (Health))]
[RequireComponent(typeof(PlayerDeathHandler))]

public class Enemy : MonoBehaviour, IAttacker,IDamageable
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private AttackPoint _attackpoint;

    private MoverEnemy _mover;
    private PatrollerEnemy _patroler;
    private Rotator _rotator;
    private Rigidbody2D _rigidbody;
    private EnemyVision _rayCast;
    private Follower _follower;
    private CharacterAnimator _characterAnimator;
    private ChekerHero _chekerHero;
    private Health _healthBar;
    private PlayerDeathHandler _playerDeathHandler;

    private int _rightRotation = 0;
    private int _leftRotation = 180;
    private int _indexPoints;
    private int _firstPoint = 0;
    private int _secondPoint = 1;
    private int _damage = 20;

    private float _attackRadius = 0.8f;

    private Vector2 _triggerPosition;
    private Vector2 _pointRotationLeft;
    private Vector2 _pointRotationRight;

    private bool _isSeening = false;
    private bool _isMoving = false;
    private bool _isAttacked = false;

    private void Awake()
    {
        _mover = GetComponent<MoverEnemy>();
        _patroler = GetComponent<PatrollerEnemy>();
        _rotator = GetComponent<Rotator>();
        _healthBar = GetComponent<Health>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _follower = GetComponent<Follower>();
        _characterAnimator = GetComponent<CharacterAnimator>(); ;
        _rayCast = GetComponentInChildren<EnemyVision>();
        _chekerHero = GetComponentInChildren<ChekerHero>();
        _playerDeathHandler=GetComponent<PlayerDeathHandler>();
    }


    private void FixedUpdate()
    {
       if(_isAttacked == false)
            _mover.Move(_triggerPosition);
    }

    private void Update()
    {
        _isSeening = _rayCast.Search();

        _isAttacked = _chekerHero.GetState();

        if (_isSeening == false && _isAttacked == false) 
        {
            _isMoving = true;
            _patroler.Patrol();
            _triggerPosition = _patroler.GetTrigger();
        }
        else if(_isSeening==true)
        {
            _isMoving = true;
            _triggerPosition = _follower.GetTrigger();
            _mover.Move(_triggerPosition);
            
        }
        else
        {
            _isMoving = false;
        }
   
        _characterAnimator.PlayWalked(_isMoving);
        _characterAnimator.PlayAttack(_isAttacked);
    }

    private void OnEnable()
    {
        _healthBar.HealthChanged += _playerDeathHandler.Death;
        _patroler.Rotate += _rotator.Rotate;
        _rayCast.SeeHero += _follower.SetTrigger;
    }

    private void OnDisable()
    {
        _healthBar.HealthChanged -= _playerDeathHandler.Death;
        _patroler.Rotate -= _rotator.Rotate;
        _rayCast.SeeHero -= _follower.SetTrigger;
    }

    public void TakeDamage(float damage)
    {
        _healthBar.TakeDamage(damage);
    }

    public void Attack() 
    {
        Collider2D[] enemyTarget = Physics2D.OverlapCircleAll(_attackpoint.transform.position, _attackRadius);

        foreach (Collider2D enemy in enemyTarget)
        {
            if (enemy.TryGetComponent(out Hero target))
            {
                target.TakeDamage(_damage);
                Debug.Log("Hit");
            }
        }
    }

    public bool GetState()
    {
        return _isMoving;
    }
}
