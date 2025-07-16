using UnityEngine;

public class Rotator : MonoBehaviour
{
    public void Rotate(float direction)
    {
            Quaternion rotation = transform.rotation;

            rotation.y = direction;

            transform.rotation = rotation;
    }
}
