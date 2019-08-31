using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private Image HealthBar;
    [SerializeField]
    private Enemy enemy;
    
    public float health;
    //its just to fit in the fill amount variable in the image, because it goes between 0-1 and we wanted to be between 0-health
    private float initialHealth;

    void Start()
    {
        initialHealth = health;
    }
    //simple recieve damage function
    public void RecieveDmg(float damage)
    {
        Debug.Log(health + "initial health:" + initialHealth);

        health -= damage;
        //we update the health every time it recieves damage, theres no need to update it each frame
        HealthBar.fillAmount = health / initialHealth;
        if (health <= 0)
        {
            enemy.Delete();
        }
    }
}
