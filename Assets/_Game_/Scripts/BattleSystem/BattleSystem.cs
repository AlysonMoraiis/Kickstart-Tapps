using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };
public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject skeletonPrefab;
    [SerializeField]
    private GameObject mummyPrefab;
    private GameObject trueEnemy;
    [SerializeField]
    private Transform playerBattleStation;
    [SerializeField]
    private Transform enemyBattleStation;
    [SerializeField]
    private Unit playerUnit;

    private GameObject playerGO;

    public PlayerAnimations playerAnimations;
    public EnemyAnimations enemyAnimations;


    public event Action onAttack;

    [Header("Hud")]
    [SerializeField]
    private BattleHud enemyHUD;
    [SerializeField]
    private BattleHud playerHUD;

    [Header("Others")]
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Text battleResultText;
    [SerializeField]
    private Button quitButton;

    public event Action<int> OnWinning;

    private Unit enemyUnit;
    private BattleState state;

    private bool canBattle = true;

    private void OnEnable()
    {
        state = BattleState.START;
        //StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle(string enemyName)
    {
        quitButton.gameObject.SetActive(false);
        battleResultText.text = "";
        if (canBattle)
        {
            playerGO = Instantiate(playerPrefab, playerBattleStation);
            playerAnimations = playerGO.GetComponent<PlayerAnimations>();
            playerAnimations.battleSystem = this;
        }
        //playerUnit = playerGO.GetComponent<Unit>();
        switch (enemyName) 
        {
            case "Skeleton":
            {
                trueEnemy = skeletonPrefab;
                break;
            }
            case "Mummy":
            {
                trueEnemy = mummyPrefab;
                break;
            }
        }
        if (canBattle)
        {
            GameObject enemyGO = Instantiate(trueEnemy, enemyBattleStation);
            enemyUnit = enemyGO.GetComponent<Unit>();
            enemyAnimations = enemyGO.GetComponent<EnemyAnimations>();
            enemyAnimations.battleSystem = this;
        }

        playerHUD.HUD(playerUnit);
        enemyHUD.HUD(enemyUnit);

        canBattle = false;
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    private void PlayerTurn()
    {

    }
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.Attack());
        onAttack?.Invoke();
        playerAnimations.AttackAnim();
        enemyAnimations.TakeDamageAnim();

        //GameObject dmgPopUpGO = Instantiate(dmgPopUpText, dmgPopupLocation);
        enemyHUD.SetHP(enemyUnit.CurrentHP);
        state = BattleState.ENEMYTURN;
        yield return new WaitForSeconds(1f);
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
        bool isDead = playerUnit.TakeDamage(enemyUnit.Attack());
        playerAnimations.TakeDamageAnim();
        enemyAnimations.AttackAnim();
        playerHUD.SetHP(playerUnit.CurrentHP);
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
        canBattle = true;
        quitButton.gameObject.SetActive(true);
        if (state == BattleState.WON)
        {
            battleResultText.text = "You win";

            OnWinning?.Invoke(5);
        }
        else if (state == BattleState.LOST)
        {
            battleResultText.text = "You lose";
            gameOverPanel.SetActive(true);
            playerUnit.DefaultStats();
        }
        Destroy(playerGO);
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
