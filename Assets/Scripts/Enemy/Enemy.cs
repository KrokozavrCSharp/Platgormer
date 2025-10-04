using System.Net;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Hero _target;

    private MoverEnemy _mover;
    private PatrollerEnemy _patroler;
    private Rotator _rotator;
    private TakerDamage _chakerDamage;
    private Rigidbody _rigidbody;

    private RaycastHit2D _hit;
    private Ray2D _view;

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

    private void Start()
    {
        _mover = GetComponent<MoverEnemy>();
        _patroler = GetComponent<PatrollerEnemy>();
        _rotator = GetComponent<Rotator>();
        _chakerDamage = GetComponent<TakerDamage>();

        _pointRotationRight = _wayPoints[_firstPoint].position;
        _pointRotationLeft = _wayPoints[_secondPoint].position;

        _triggerPosition = _wayPoints[_secondPoint].position;
    }

    private void FixedUpdate()
    {
        _mover.Move(_triggerPosition);
    }

    private void Update()
    {
        _view = new Ray2D(transform.position, Vector2.right);

        Debug.DrawRay(_view.origin, _view.direction);

         _hit= Physics2D.Raycast(_view.origin, _view.direction, 5f);

        if (_hit.collider.TryGetComponent(out Hero player))
            Debug.Log("bam");


        if (_isSeening == false)
            Patrol();
        else
            Follow(_target);

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health=_chakerDamage.TakeDamage(_health,damage);
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

    /*private bool Cheker()
    {
        if (Physics.Raycast(_view, out _hit))
        {
            Debug.Log(_hit.transform.name);
        }

        return _isSeening;
    }*/

    private void Follow(Hero trigger)
    {
        _rigidbody.velocity = Vector2.MoveTowards(transform.position,  trigger.transform.position,100f);
    }
}


