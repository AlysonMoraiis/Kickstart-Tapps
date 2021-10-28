using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Slider hpSlider;

    public void HUD(Unit unit)
    {
        hpSlider.maxValue = unit.MaxHP;
        hpSlider.value = unit.CurrentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
