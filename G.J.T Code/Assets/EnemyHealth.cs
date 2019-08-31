using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    //@Zebul you can edit this for the different types of enemies
    public float Health;
    //its just to fit in the fill amount variable in the image, because it goes between 0-1 and we wanted to be between 0-health
    private float InitialHealth;

    void Start()
    {
        InitialHealth = Health;
    }
    //simple recieve damage function
    public void RecieveDmg(float Damage)
    {
        Health -= Damage;
        //we update the health every time it recieves damage, theres no need to update it each frame
        HealthBar.fillAmount = Health / InitialHealth;
    }

    void Update()
    {
        
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
