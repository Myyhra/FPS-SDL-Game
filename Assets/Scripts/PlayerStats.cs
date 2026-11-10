using UnityEngine;
public class PlayerStats : MonoBehaviour, IPlayerHP, IPlayerHeat
{
    [SerializeField] float playerHP = 100f;
    [SerializeField] float playerArmor = 50f;
    float playerHeat;
    bool playerIsInheat;
    bool playerCanHeal;

    public void IPlayerHP(float HP)
    {
        playerHP += HP;

        if (playerHP <= 0)
        {
            playerHP = 0;

            //Insert Death
        }

        if (playerHP >= 100)
        {
            playerHP = 100;
        }

        Debug.Log("Receiving HP Value");
    }

    public void IPlayerHeat(float heat, bool isInHeat)
    {
        playerHeat = heat;
        playerIsInheat = isInHeat;
        Debug.Log($"Taking Heat");
    }
}
