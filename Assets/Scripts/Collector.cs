using UnityEngine;

public class Collector : MonoBehaviour
{
    public event System.Action<int> TakeAid;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
            Destroy(coin.gameObject);
         

        if (other.TryGetComponent(out Aid aid))
        {
            int treatment = aid.GetAid();
            TakeAid?.Invoke(treatment);
            Destroy(aid.gameObject);
        }
    }
}
