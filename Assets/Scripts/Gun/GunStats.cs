using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "Scriptable Objects/GunStats")]
public class GunStats : ScriptableObject
{
    // public Camera camera;
    public int maxAmmo;
    public float damage;
    public float fireRate;
    public float reloadTimer;
    public float maxHitDistance;
    public LayerMask HittableLayers;

}
