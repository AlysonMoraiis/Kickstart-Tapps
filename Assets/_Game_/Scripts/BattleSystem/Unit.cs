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

    public Text floatingText;
    public Transform dmgPopupLocation;

    public int Attack()
    {
        int dmg = Random.Range(minDmg, maxDmg);
        Debug.Log("Causou " + dmg + " de dano");
        return dmg;
    }
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        floatingText.text = dmg.ToString();
        Instantiate (floatingText, dmgPopupLocation);

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
