using StarterAssets;
using UnityEngine;

public class SniperGun : MonoBehaviour
{
    public GunStats gunStats;
    [SerializeField] Camera cam;
    bool canShoot = true;

    public StarterAssetsInputs inputs;
    void Awake()
    {
        inputs.GetComponentInParent<StarterAssetsInputs>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(inputs.shoot && canShoot)
        {
            RaycastTarget();
            Debug.Log($"Shooting Sniper");
        }
    }

    void RaycastTarget()
    {
        Vector3 centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        // var cam = gunStats.camera;
        Ray ray = cam.ScreenPointToRay(centerScreen);

        if (Physics.Raycast(ray, out RaycastHit hit, gunStats.maxHitDistance, gunStats.HittableLayers, QueryTriggerInteraction.Ignore))
        {
            IDamageable damage = hit.collider.gameObject.GetComponent<IDamageable>();

            damage.TakeDamage(gunStats.damage);
        }

        Debug.DrawRay(ray.origin, ray.direction * gunStats.maxHitDistance, Color.cyan);

    }


}
