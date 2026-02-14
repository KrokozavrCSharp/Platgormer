using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _positionHero;

    private float speed = 2;

    public void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(_positionHero.position.x,transform.position.y), Time.deltaTime * speed);
    }
}
