using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _positionHero;

    public Vector2 _position;

    public void SetTrigger(Vector2 position)
    {
        _position = position;
    }

    public Vector2 GetTrigger()
    {
        return new Vector2(_position.x, transform.position.y);
    }
}
