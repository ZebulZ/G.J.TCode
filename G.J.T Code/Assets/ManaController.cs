using UnityEngine;
using UnityEngine.UI;

public class ManaController : MonoBehaviour
{
    private float Initialmana;
    [SerializeField] private float mana;
    [SerializeField] private Image manaBar;

    private void Start()
    {
        Initialmana = mana;
        manaBar.fillAmount = mana / Initialmana;
    }

    public void SubstractMana(float SubstractAmmount)
    {
        mana -= SubstractAmmount;
        manaBar.fillAmount = mana / Initialmana;
    }
}
