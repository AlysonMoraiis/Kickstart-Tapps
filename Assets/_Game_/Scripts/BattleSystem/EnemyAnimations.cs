using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    public BattleSystem battleSystem;

    [SerializeField]
    private Animator anim;


    private void Start() 
    {
        anim = GetComponent<Animator>();
    }

    public void AttackAnim()
    {
        Debug.Log("Atacouuu");
        anim.SetTrigger("Attack");
    }

    public void TakeDamageAnim()
    {
        anim.SetTrigger("Damage");
    }
}