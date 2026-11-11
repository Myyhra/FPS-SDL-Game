using UnityEngine;
using UnityEngine.UI;

public class TakeDamageObject : MonoBehaviour, IDamageable
{

    [SerializeField]float HP = 100f;
    public Slider sliderHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sliderHP.maxValue = HP;
        sliderHP.value = HP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        sliderHP.value = HP;
        if(HP <= 0f)
        {
            HP = 0f;
            Debug.Log($"{gameObject.name} has died");
        }
        Debug.Log($"{gameObject.name} is taking Damage");
    }
}
