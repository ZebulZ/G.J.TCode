using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //nothing special here
    public float Health = 100;
    [SerializeField] private Image HealthBar;

    public float InitilaHealth;

    void Start()
    {
        InitilaHealth = Health;
    }

    public void SubstractHealth(float Ammount)
    {
        Health -= Ammount;
        HealthBar.fillAmount = Health / InitilaHealth;
    }

    public void AddHealth(float HealAmmount)
    {
        Health += HealAmmount;
        HealthBar.fillAmount = Health / InitilaHealth;
    }
}
