using UnityEngine;

public class RotatorEnemy : MonoBehaviour
{
    public void Rotate(int direction)
    {         
            Quaternion rotation = transform.rotation;

            rotation.y = direction;

            transform.rotation = rotation;
        
    }
}
