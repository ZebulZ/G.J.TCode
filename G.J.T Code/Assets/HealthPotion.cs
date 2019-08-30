using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private float HealAmmount;
    [SerializeField] private Sprite Icon;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerHealth>().Health != collision.GetComponent<PlayerHealth>().InitilaHealth)
            {
                collision.GetComponent<PlayerHealth>().AddHealth(HealAmmount);
                Destroy(gameObject);
            }
        }
    }
}
