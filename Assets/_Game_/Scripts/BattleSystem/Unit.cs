using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;


    public int minDmg;
    public int maxDmg;

    public int maxHP;
    public int currentHP;

    public int Attack()
    {
        int dmg = Random.Range(minDmg, maxDmg);
        Debug.Log(dmg);
        return dmg;
    }
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

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
