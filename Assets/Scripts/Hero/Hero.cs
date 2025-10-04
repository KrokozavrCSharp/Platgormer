using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private ChekerGround _chekerGround;
    [SerializeField] private AttackPoint _attackpoint;

    private float _attackRadius = 0.25f;

    private MoverHero _move;
    private JumperHero _jump;
    private Rotator _rotate;
    private InputService _inputService;
    private CharacterAnimator _characterAnimator;
    private Attacker _attack;

    private Rigidbody2D _rigidbody;

    private float _directionX;
    private float _directionY = 0;
    private float _rightRotation = 180f;
    private float _leftRotation = 0f;

    private bool _isGround = false;
    private bool _isMoving = false;
    private bool _isAttacked = false;

    private int _damage = 1;


    private void Start()
    {
        _move = GetComponent<MoverHero>();
        _jump = GetComponent<JumperHero>();
        _rotate = GetComponent<Rotator>();
        _inputService = GetComponent<InputService>();
        _characterAnimator = GetComponent<CharacterAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _attack = GetComponent<Attacker>();
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

        if (_inputService.GetMovement() > 0)
            _rotate.Rotate(_leftRotation);

        if (_inputService.GetMovement() < 0)
            _rotate.Rotate(_rightRotation);

        if (_inputService.IsAttacked())
        {
            _isAttacked = true;
            Attack();
        }
        else
            _isAttacked = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
            Destroy(coin.gameObject);
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
}