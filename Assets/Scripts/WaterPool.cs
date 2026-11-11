using UnityEngine;

public class WaterPool : MonoBehaviour
{
    [Range(0.1f, 100f)]
    [SerializeField] float HealAmount = 1f;
    [Range(0.1f, 200f)]
    [SerializeField] float HealAmountBaseMultiplier = 1f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IPlayerHP playerHP = other.gameObject.GetComponentInChildren<IPlayerHP>();
            IPlayerRaycastSun playerRaySun = other.gameObject.GetComponentInChildren<IPlayerRaycastSun>();

            playerHP.IPlayerHP(HealPool());
            playerRaySun.SetHeat(0f);
            
            Debug.Log(playerHP == null ? "Player HP is NULL" : "Player HP is FOUND");
            Debug.Log($"Water player");
        }
    }

    float HealPool()
    {
        float num;
        num = (HealAmount * (HealAmountBaseMultiplier / 100f));
        return num;
    }
}
