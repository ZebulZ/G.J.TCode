using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //nothing special here
    public float Health = 100;
    [SerializeField] private Image HealthBar;

    private float InitilaHealth;

    void Start()
    {
        InitilaHealth = Health;
    }

    void Update()
    {
        HealthBar.fillAmount = Health / InitilaHealth;
    }
}
