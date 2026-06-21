using UnityEngine;

public class PatrollerEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Rotator _rotator;

    public event System.Action<Vector2> Rotate;

    private Vector2 _triggerPosition;
    private Vector2 _pointRotationLeft;
    private Vector2 _pointRotationRight;

    private int _firstPoint = 0;
    private int _secondPoint = 1;
    private int _indexPoints;

    private void Start()
    {
        _pointRotationRight = _wayPoints[_firstPoint].position;
        _pointRotationLeft = _wayPoints[_secondPoint].position;

        _triggerPosition = _wayPoints[_secondPoint].position;
    }

    public void Patrol()
    {

        if (Mathf.Approximately(transform.position.x, _pointRotationRight.x))
        {
            _indexPoints = _firstPoint;
            Rotate?.Invoke(_pointRotationLeft);
            _indexPoints = GetNextPosition(_indexPoints, _wayPoints.Length);
            _triggerPosition = _wayPoints[_indexPoints].position;
        }

        if (Mathf.Approximately(transform.position.x, _pointRotationLeft.x))
        {
            _indexPoints = _secondPoint;
            Rotate?.Invoke(_pointRotationRight);
            _indexPoints = GetNextPosition(_indexPoints, _wayPoints.Length);
            _triggerPosition = _wayPoints[_indexPoints].position;
        }
    }

    public Vector2 GetTrigger()
    {
        return _triggerPosition;
    }

    private int GetNextPosition(int index,int countPoints)
    {
        index = ++index % countPoints;
        
        return index;
    }
}