using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour, IPlayerHP, IPlayerHeat, IPlayerGetMaxHeat
{
    [SerializeField] float maxPlayerHP = 100f;
    [SerializeField] float currentPlayerHP = 100f;
    [SerializeField] float maxPlayerArmor = 100f;
    [SerializeField] float currentPlayerArmor = 50f;
    float maxPlayerHeat;
    float currentPlayerHeat;
    bool playerIsInheat;
    bool playerCanHeal;

    [Header("UI")]
    public Slider healthSlider;
    public Slider heatSlider;

    void Start()
    {
        currentPlayerHP = maxPlayerHP;
        currentPlayerArmor = maxPlayerArmor;
        currentPlayerArmor = maxPlayerHeat;

        healthSlider.maxValue = maxPlayerHP;
        heatSlider.maxValue = maxPlayerHeat;
        healthSlider.value = currentPlayerHP;
        heatSlider.value = currentPlayerHeat;

        //temporary check
        playerCanHeal = true;
    }

    public void IPlayerHP(float HP)
    {

        currentPlayerHP += HP;


        if (currentPlayerHP <= 0f)
        {
            currentPlayerHP = 0f;

            Debug.Log($"{gameObject.name} has Died");
            //Insert Death
        }

        if (currentPlayerHP >= maxPlayerHP)
        {
            currentPlayerHP = maxPlayerHP;
        }

        healthSlider.value = currentPlayerHP;
        Debug.Log("Receiving HP Value");
    }

    public void IPlayerHeat(float heat, bool isInHeat)
    {
        currentPlayerHeat = heat;
        playerIsInheat = isInHeat;

        heatSlider.value = currentPlayerHeat;
        
    }

    public void MaxHeat(float max)
    {
        maxPlayerHeat = max;
    }
}
