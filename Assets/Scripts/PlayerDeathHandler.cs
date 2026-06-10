using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    public void Death(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
