using UnityEngine;

public class PlayerRaycastSun : MonoBehaviour
{
    public PlayerStats playerStats;
    IPlayerHP IplayerHP;
    IPlayerHeat IplayerHeat;
    RaycastHit rayHit;
    GameObject target;
    float heat;
    [SerializeField] LayerMask layerMask;

    void Start()
    {
        target = GameObject.Find("Sun");
        IplayerHeat = GetComponent<IPlayerHeat>();
    }

    void Update()
    {
        Detect();
    }

    void Detect()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        float dist = Vector3.Distance(target.transform.position, transform.position);

        Ray ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out rayHit, dist, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (rayHit.collider.CompareTag("Sun"))
            {
                IplayerHeat.IPlayerHeat();
            }
            else
            {
                Debug.Log($"Detecting: {rayHit.transform.name} instead");
            }
        }
        Debug.DrawRay(transform.position, direction * dist, Color.cyan);
    }


}