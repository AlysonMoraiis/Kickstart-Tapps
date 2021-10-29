using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [Header("Defaults")]
    [SerializeField]
    private int defaultMinDmg;
    [SerializeField]
    private int defaultMaxDmg;

    [Header("Status")]
    [SerializeField]
    private int unitLevel;
    [SerializeField]
    private int minDmg;
    [SerializeField]
    private int maxDmg;
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int currentHP;

    public int MaxHP
    {
        get { return maxHP;}
        set { maxHP = value;}
    }
    public int CurrentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }
    public int MaxDmg
    {
        get { return maxDmg; }
        set { maxDmg = value; }
    }
    public int MinDmg
    {
        get { return minDmg; }
        set { minDmg = value; }
    }

    public void DefaultStats()
    {
        minDmg = defaultMinDmg;
        maxDmg = defaultMaxDmg;
        currentHP = maxHP;
    }

    public int Attack()
    {
        int dmg = Random.Range(minDmg, maxDmg);
        Debug.Log("Causou " + dmg + " de dano");
        return dmg;
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if(currentHP <= 0)
        {
            Destroy(gameObject, 0.5f);
            return true;
        }
        else
        {
            return false;
        }
    }
}
