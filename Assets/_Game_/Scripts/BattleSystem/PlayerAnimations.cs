using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public BattleSystem battleSystem;

    [SerializeField]
    private Animator anim;

    private void OnEnable()
    {
        battleSystem.onAttack += AttackAnim;
    }
    private void OnDisable()
    {
        battleSystem.onAttack -= AttackAnim;
    }

    public void AttackAnim()
    {
        Debug.Log("Atacouuu");
        anim.SetTrigger("Attack");
    }
}
//////////////n�o t� funcionando, apagar esse script