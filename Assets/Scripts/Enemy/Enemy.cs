using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Hero _target;
    [SerializeField] private AttackPoint _attackpoint;

    private MoverEnemy _mover;
    private PatrollerEnemy _patroler;
    private Rotator _rotator;
    private Rigidbody2D _rigidbody;
    private RayCast _rayCast;
    private Follower _follower;
    private CharacterAnimator _characterAnimator;
    private ChekerHero _chekerHero;
    private Health _healthBar;

    private int _rightRotation = 0;
    private int _leftRotation = 180;
    private int _indexPoints;
    private int _firstPoint = 0;
    private int _secondPoint = 1;
    private int _health = 100;
    
    private Vector2 _triggerPosition;
    private Vector2 _pointRotationLeft;
    private Vector2 _pointRotationRight;

    private bool _isSeening = false;
    private bool _isMoving = false;
    public bool _isAttacked = false;

    private void Start()
    {
        _mover = GetComponent<MoverEnemy>();
        _patroler = GetComponent<PatrollerEnemy>();
        _rotator = GetComponent<Rotator>();
        _healthBar = GetComponent<Health>();
        _rigidbody =GetComponent<Rigidbody2D>();
        _follower=GetComponent<Follower>();
        _characterAnimator = GetComponent<CharacterAnimator>(); ;
        _rayCast =GetComponentInChildren<RayCast>();
        _chekerHero=GetComponentInChildren<ChekerHero>();

        _pointRotationRight = _wayPoints[_firstPoint].position;
        _pointRotationLeft = _wayPoints[_secondPoint].position;

        _triggerPosition = _wayPoints[_secondPoint].position;
    }

    private void FixedUpdate()
    {
       if(_isAttacked == false)
            _mover.Move(_triggerPosition);
    }

    private void Update()
    {
        _isSeening = _rayCast.See();

        _isAttacked = _chekerHero.GetState();

        if (_isSeening == false && _isAttacked == false) 
        {
            _isMoving = true;
            Patrol();
        }
        else if(_isSeening==true)
        {
            _isMoving = true;
            _follower.Follow();
        }
        else
        {
            _isMoving = false;
        }

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
   
        _characterAnimator.PlayWalked(_isMoving);
        _characterAnimator.PlayAttack(_isAttacked);
    }

    public void TakeDamage(int damage)
    {
        _health= _healthBar.TakeDamage(_health,damage);
    }

    private void Patrol()
    {
        if (transform.position.x == _wayPoints[_indexPoints].position.x)
        {
            _indexPoints = _patroler.GetNextPosition(_indexPoints, _wayPoints.Length);
            _triggerPosition = _wayPoints[_indexPoints].position;
        }

        if (Mathf.Approximately(transform.position.x, _pointRotationRight.x))
        {
            _indexPoints = _firstPoint;
            _rotator.Rotate(_rightRotation);
            _indexPoints = _patroler.GetNextPosition(_indexPoints, _wayPoints.Length);
            _triggerPosition = _wayPoints[_indexPoints].position;
        }

        if (Mathf.Approximately(transform.position.x, _pointRotationLeft.x))
        {
            _indexPoints = _secondPoint;
            _rotator.Rotate(_leftRotation);
            _indexPoints = _patroler.GetNextPosition(_indexPoints, _wayPoints.Length);
            _triggerPosition = _wayPoints[_indexPoints].position;
        }
    }
}
