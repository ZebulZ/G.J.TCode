using UnityEngine;
using UnityEngine.UI;

public class ManaController : MonoBehaviour
{
    [HideInInspector] public float Initialmana;
    public float mana;
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

    public void AddMana(float AddAmmount)
    {
        mana += AddAmmount;
        if(mana > Initialmana)
        {
            mana = Initialmana;
        }
        manaBar.fillAmount = mana / Initialmana;
    }
}
