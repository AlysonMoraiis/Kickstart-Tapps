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
            playerUnit.MinDmg += 3;
            playerUnit.MaxDmg += 3;
            Debug.Log("dmg + 3");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && collectableName == "life")
        {
            playerUnit.CurrentHP += 15;
            Debug.Log("life + 15");
            Destroy(gameObject);

            if(playerUnit.CurrentHP > playerUnit.MaxHP)
            {
                playerUnit.CurrentHP = playerUnit.MaxHP;
            }
        }
    }
}
