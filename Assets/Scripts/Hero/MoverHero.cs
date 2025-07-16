using UnityEngine;

public class MoverHero : MonoBehaviour
{
    private float _speed = 100f;

    public void Move(Rigidbody2D rigidbody, float directionX,float directionY)
    {
        rigidbody.velocity = new Vector2(directionX * _speed * Time.fixedDeltaTime, directionY);
    }
}