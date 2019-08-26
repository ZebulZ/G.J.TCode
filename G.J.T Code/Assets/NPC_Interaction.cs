using UnityEngine;

public class NPC_Interaction : MonoBehaviour
{
    [SerializeField] private Collider2D col;

    private void OnTriggerStay(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
