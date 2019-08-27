using System.Collections;
using UnityEngine;
using TMPro;

public class NPC_Interaction : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    [SerializeField] private TMP_Text Text;
    [SerializeField] private GameObject TextFied;
    [SerializeField] private Animator Anim;

    [TextArea]
    public string[] Dialogues;
    [TextArea]
    public string Nodialog;

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
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(DialogueCount > Dialogues.Length)
            {
                DialogueCount = Dialogues.Length;
            }
        }
    }

   public void Yes()
    {
        DialogueCount++;
        Text.text = Dialogues[DialogueCount];
    }

   public void No()
    {
        Text.text = Nodialog;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Anim.SetBool("Enter", false);
            StartCoroutine(WaitForTransition());
            DialogueCount = 0;
        }
    }

    IEnumerator WaitForTransition()
    {
        yield return new WaitForSeconds(0.5f);
        TextFied.SetActive(false);
    }
}
