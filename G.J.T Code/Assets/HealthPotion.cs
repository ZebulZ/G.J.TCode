using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private float HealAmmount;
    [SerializeField] private Sprite Icon;
    [SerializeField] private GameObject Text;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Icon;
        Text.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Text.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                collision.GetComponent<PlayerHealth>().AddHealth(HealAmmount);
                 Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Text.SetActive(false);
    }
}
