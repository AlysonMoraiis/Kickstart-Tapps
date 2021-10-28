using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;


    public int minDmg;
    public int maxDmg;

    public int maxHP;
    public int currentHP;

    public int dmgTest;

    [SerializeField]
    private Text dmgPopUpText;
    public int Attack()
    {
        int dmg = Random.Range(minDmg, maxDmg);
        Debug.Log("Causou " + dmg + " de dano");
        return dmg;
    }
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        //dmgPopUpText.text = dmg.ToString();
        dmgTest = dmg;
        if(currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
