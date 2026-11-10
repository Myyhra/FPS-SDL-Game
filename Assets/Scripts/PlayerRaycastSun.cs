using UnityEngine;

public class PlayerRaycastSun : MonoBehaviour, IPlayerRaycastSun
{
    IPlayerHP IplayerHP;
    IPlayerHeat IplayerHeat;
    RaycastHit rayHit;
    GameObject target;
    float heat;
    [SerializeField] LayerMask layerMask;

    [Header("Player Heat")]
    float builtHeat;
    float playerHeat;
    [Range(0.1f, 100f)]
    [SerializeField] float heatBuildSpeed = 100f;
    [Range(0.1f, 200f)]
    [SerializeField] float heatBuildBaseMultiplier = 1f;
    [SerializeField] float heatThreshold = 10f;
    [Range(0.1f, 100f)]
    [SerializeField] float tickDamage = 1f;
    [Range(0.1f, 200f)]
    [SerializeField] float tickDamageSpeedBaseMultiplier = 1f;

    void Start()
    {
        target = GameObject.Find("Sun");
        IplayerHP = GetComponent<IPlayerHP>();
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
                PlayerHeat(true);
            }
            else
            {
                PlayerHeat(false);
                Debug.Log($"Detecting: {rayHit.transform.name} instead");
            }
        }
        Debug.DrawRay(transform.position, direction * dist, Color.cyan);
    }
    public void PlayerHeat(bool isInHeat)
    {
        float tick = (((tickDamageSpeedBaseMultiplier / 100f) * tickDamage) * Time.deltaTime);

        if (isInHeat == true)
        {
            playerHeat += (heatBuildBaseMultiplier * (heatBuildSpeed / 100f)) * Time.deltaTime;
            builtHeat = playerHeat;
            IplayerHeat.IPlayerHeat(playerHeat, isInHeat);

            if (playerHeat >= heatThreshold)
            {
                playerHeat = heatThreshold;
                IplayerHP.IPlayerHP(-tick);
            }
        }
        else
        {
            IplayerHeat.IPlayerHeat(builtHeat, isInHeat);
        }

    }

    public void SetHeat(float num)
    {
        playerHeat = num;
        builtHeat = num;
        IplayerHeat.IPlayerHeat(playerHeat, false);

    }
}

public interface IPlayerRaycastSun
{
    void SetHeat(float num);
}