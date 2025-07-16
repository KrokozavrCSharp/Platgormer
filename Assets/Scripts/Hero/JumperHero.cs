using UnityEngine;

public class JumperHero : MonoBehaviour
{
    private float _jumpForce = 100f;

    public void Jump(Rigidbody2D rigidbody)
    {
        rigidbody.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }    
}