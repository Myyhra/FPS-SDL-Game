using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public Transform target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Raytest();
    }

    void Raytest()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        float dist = Vector3.Distance(transform.position,target.position);
        if(Physics.Raycast(transform.position,dir,out RaycastHit hit,dist))
        {
            Debug.Log($"Detecting {hit.collider.name}");
        }
    }
}
