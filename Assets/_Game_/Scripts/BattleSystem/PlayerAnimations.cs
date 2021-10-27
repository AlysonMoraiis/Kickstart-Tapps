using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private BattleSystem battleSystem;

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

    private void AttackAnim()
    {
        Debug.Log("Atacouuu");
        anim.SetBool("attackBool", true);
    }
}
//////////////não tá funcionando, apagar esse script