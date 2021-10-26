using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public Unit playerUnit;
    Unit enemyUnit;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public Text battleResultText;

    public Button quitButton;

    public event Action<int> OnWinning;


    public BattleState state;
    void Start()
    {
    }

    private void OnEnable()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        quitButton.gameObject.SetActive(false);
        battleResultText.text = "";
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        //playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        playerHUD.HUD(playerUnit);
        enemyHUD.HUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    /// <summary>
    /// //ultimo
    /// </summary>
    private void PlayerTurn()
    {

    }
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
            state = BattleState.ENEMYTURN;
        yield return new WaitForSeconds(2f);
        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

         
    }

    void EndBattle()
    {
        Debug.Log("Acabou");
        quitButton.gameObject.SetActive(true);
        if (state == BattleState.WON)
        {
            battleResultText.text = "You win";
            OnWinning?.Invoke(5);
        }
        else if (state == BattleState.LOST)
        {
            battleResultText.text = "You lose";
        }
    }
    public void OnAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }

}
