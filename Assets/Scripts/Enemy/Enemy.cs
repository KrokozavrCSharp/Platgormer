using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private MoverEnemy _mover;
    private PatrollerEnemy _patroler;
    private RotatorEnemy _rotater;

    private int _rightRotation = 0;
    private int _leftRotation = 180;
    private int _indexPoints;
    private int _firstPoint = 0;
    private int _secondPoint = 1;

    private Vector2 _triggerPosition;

    private Vector2 _pointRotationLeft;
    private Vector2 _pointRotationRight;

    private void Start()
    {
        _mover=GetComponent<MoverEnemy>();
        _patroler=GetComponent<PatrollerEnemy>();
        _rotater=GetComponent<RotatorEnemy>();

        _pointRotationRight = _wayPoints[_firstPoint].position;
        _pointRotationLeft = _wayPoints[_secondPoint].position;

        _triggerPosition= _wayPoints[_secondPoint].position;
    }

    private void FixedUpdate()
    {
        _mover.Move(_triggerPosition);
    }

    private void Update()
    {
        if (transform.position.x == _wayPoints[_indexPoints].position.x)
        {
            _indexPoints = _patroler.GetNextPosition(_indexPoints,_wayPoints.Length);
            _triggerPosition = _wayPoints[_indexPoints].position;
        }

        if (Mathf.Approximately(transform.position.x,_pointRotationRight.x))
        {
            _indexPoints = _firstPoint;
            _rotater.Rotate(_rightRotation);
            _indexPoints = _patroler.GetNextPosition(_indexPoints, _wayPoints.Length);
            _triggerPosition = _wayPoints[_indexPoints].position;
        }  

        if (Mathf.Approximately(transform.position.x,_pointRotationLeft.x))
        {
            _indexPoints = _secondPoint;
            _rotater.Rotate(_leftRotation);
            _indexPoints = _patroler.GetNextPosition(_indexPoints, _wayPoints.Length);
            _triggerPosition = _wayPoints[_indexPoints].position;
        }
    }
}
