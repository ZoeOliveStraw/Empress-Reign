using TMPro;
using UnityEngine;

public class HUD_Controller : MonoBehaviour
{
    [SerializeField] public HUD_Meter meterHealth;
    [SerializeField] public HUD_Meter meterStamina;
    [SerializeField] public HUD_Meter meterMana;
    [SerializeField] public TextMeshProUGUI selectionLabel;

    public void SetHealth(int health, int maxHealth)
    {
        meterHealth.Set(health, maxHealth);
    }

    public void SetStamina(int stamina, int maxStamina)
    {
        meterStamina.Set(stamina, maxStamina);
    }

    public void SetMana(int mana, int maxMana)
    {
        meterMana.Set(mana, maxMana);
    }

    public void SetSelectionLabel(string label)
    {
        selectionLabel.text = label;
    }
}
