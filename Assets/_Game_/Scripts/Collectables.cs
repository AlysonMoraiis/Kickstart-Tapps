using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    private Unit playerUnit;
    [SerializeField]
    private string collectableName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collectableName == "atkUP")
        {
            playerUnit.damage += 5;
            Debug.Log("dmg + 5");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && collectableName == "life")
        {
            playerUnit.currentHP += 5;
            Debug.Log("life + 5");

            Destroy(gameObject);

            if(playerUnit.currentHP > playerUnit.maxHP)
            {
                playerUnit.currentHP = playerUnit.maxHP;
            }
        }
    }
}
