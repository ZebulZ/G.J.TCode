using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    [SerializeField] private float ManaAmmount;
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
                collision.GetComponent<ManaController>().AddMana(ManaAmmount);
                Destroy (gameObject);   
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Text.SetActive(false);
    }
}
