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
            playerUnit.MinDmg += 5;
            playerUnit.MaxDmg += 5;
            Debug.Log("dmg + 5");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && collectableName == "life")
        {
            playerUnit.CurrentHP += 10;
            Debug.Log("life + 10");
            Destroy(gameObject);

            if(playerUnit.CurrentHP > playerUnit.MaxHP)
            {
                playerUnit.CurrentHP = playerUnit.MaxHP;
            }
        }
    }
}
