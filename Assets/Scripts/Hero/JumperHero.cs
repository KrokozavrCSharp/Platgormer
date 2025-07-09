using UnityEngine;

public class JumperHero : MonoBehaviour
{
    [SerializeField]private ChekerGround _chekGround;

    private InputService _inputService;

    private float _jumpForce = 100f;

    private Rigidbody2D _rigidbody;
    private bool _isGround;

    private void Start()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
        _inputService=GetComponent<InputService>();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Jump()
    {
        _isGround = _chekGround.GetCheckGround();

        if (_inputService.IsJumpPressed() && _isGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}