using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Slider hpSlider;

    public Unit playerUnit;
    
    public void HUD(Unit unit)
    {
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void AttackUpButotn()
    {
        playerUnit.damage += 10;
        Debug.Log(playerUnit.damage);
    }
}
