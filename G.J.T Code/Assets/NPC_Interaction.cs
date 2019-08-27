using System.Collections;
using UnityEngine;
using TMPro;

public class NPC_Interaction : MonoBehaviour
{
    [SerializeField] private Animator Anim;

    [Header("TextReferences")]
    [SerializeField] private TMP_Text ButtonPositive;
    [SerializeField] private TMP_Text ButtonNegative;
    [SerializeField] private TMP_Text Text;

    [Header("Enable/Disable")]
    [SerializeField] private GameObject TextFied;
    [SerializeField] private GameObject ItemDisplay;
    [SerializeField] private GameObject Button1;
    [SerializeField] private GameObject Button2;

    [Header("Customizable Text")]
    [TextArea]
    public string[] Dialogues;
    [TextArea]
    public string Nodialog;

    [Header("Default text of yes, no")]
    [SerializeField] private string BuyPositiveDef;
    [SerializeField] private string BuyNegativeDef;

    [Header("Buy Buttons")]
    [SerializeField] private string BuyPositive;
    [SerializeField] private string BuyNegative;

    private int DialogueCount = 0;

    private void Start()
    {
        TextFied.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Anim.SetBool("Enter", true);
            //display text
            TextFied.SetActive(true);
            //equal the text to the next dialogue
            Text.text = Dialogues[0];
            ItemDisplay.SetActive(false);
            Button1.SetActive(true);
            Button2.SetActive(true);
        }
    }

    public void Yes()
    {
        DialogueCount++;
        Text.text = Dialogues[DialogueCount];
        if(DialogueCount == Dialogues.Length -1)
        {
            ItemDisplay.SetActive(true);
            ButtonNegative.text = BuyNegative;
            ButtonPositive.text = BuyPositive;
        }
    }

   public void No()
    {
        Text.text = Nodialog;
        ItemDisplay.SetActive(false);
        Button1.SetActive(false);
        Button2.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogueCount = 0;
            ItemDisplay.SetActive(false);

            ButtonNegative.text = BuyNegativeDef;
            ButtonPositive.text = BuyPositiveDef;

            Anim.SetBool("Enter", false);
            StartCoroutine(WaitForTransition());
        }
    }

    IEnumerator WaitForTransition()
    {
        yield return new WaitForSeconds(0.5f);
        TextFied.SetActive(false);
    }
}
