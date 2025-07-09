using UnityEngine;

public class Hero : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
            Destroy(coin.gameObject);
    }
}