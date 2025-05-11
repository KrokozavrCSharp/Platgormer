using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Hero>(out Hero hero))
            Destroy(gameObject);
    }
}
