using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    [SerializeField] private float ManaAmmount;
    [SerializeField] private Sprite Icon;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.GetComponent<ManaController>().mana != collision.GetComponent<ManaController>().Initialmana)
            {
                collision.GetComponent<ManaController>().AddMana(ManaAmmount);
                Destroy(gameObject);
            }
        }
    }
}
