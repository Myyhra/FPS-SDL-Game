using UnityEngine;
public class PlayerStats : MonoBehaviour, IPlayerHP, IPlayerHeat
{
    [SerializeField] float playerHP = 100f;
    [SerializeField] float playerArmor = 50f;
    float playerHeat;
    [Range(0.1f, 100f)]
    [SerializeField] float heatBuildSpeed = 100f;
    [SerializeField] float heatThreshold = 10f;

    public void PlayerHP(float HP)
    {
        playerHP = HP;
    }

    public void IPlayerHeat()
    {
        playerHeat += (heatBuildSpeed / 100f) * Time.deltaTime;
        // playerHeat += Time.deltaTime;

        Debug.Log($"Receiving Heat");

        if (playerHeat >= heatThreshold)
        {
            playerHeat = heatThreshold;
            Debug.Log($"Player is Sweating");
        }
    }
}
