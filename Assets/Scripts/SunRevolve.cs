using UnityEngine;

public class SunRevolve : MonoBehaviour
{
    public Transform target;
    public float speed = 20f;
    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
    }
}
