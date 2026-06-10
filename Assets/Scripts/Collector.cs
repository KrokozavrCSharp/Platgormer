using UnityEngine;

public class Collector : MonoBehaviour
{
    public event System.Action<Aid> TakeAid;
    public event System.Action<Coin> TakeCoin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin)) 
        {
            
            TakeCoin?.Invoke(coin);
        }
            
        if (other.TryGetComponent(out Aid aid))
        {
            TakeAid?.Invoke(aid);
        }
    }
}
