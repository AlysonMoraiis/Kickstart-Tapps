using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnLocation : MonoBehaviour
{
    [Header("Potions")]
    [SerializeField]
    private int potionsAmount;
    [SerializeField]
    List<GameObject> potionsPrefabs;
    [SerializeField]
    List<Transform> potionsLocation;

    [Header("Enemies")]
    [SerializeField]
    private int enemiesAmount;
    [SerializeField]
    List<GameObject> enemiesPrefabs;
    [SerializeField]
    List<Transform> enemiesLocation;

    [Header("DungeonPass")]
    [SerializeField]
    private int dungeonPassAmount;
    [SerializeField]
    private GameObject dungeonPassPrefab;
    [SerializeField]
    List<Transform> dungeonPassLocation;

    private int randomEnemyIndex;
    private int enemiesLocationIndex;

    private int randomPotionIndex;
    private int potionsLocationIndex;

    private int dungeonPassLocationIndex;

    private void Start()
    {
        Variation1_1();
    }
    private void Variation1_1()
    {
        for(int i = 0; i < enemiesAmount; i++)
        {
            enemiesLocationIndex = Random.Range(0, enemiesLocation.Count);
            randomEnemyIndex = Random.Range(0, enemiesPrefabs.Count);
            Instantiate(enemiesPrefabs[randomEnemyIndex], enemiesLocation[enemiesLocationIndex]);
            enemiesLocation.RemoveAt(enemiesLocationIndex);
        }
        for (int i = 0; i < potionsAmount; i++)
        {
            potionsLocationIndex = Random.Range(0, potionsLocation.Count);
            randomPotionIndex = Random.Range(0, potionsPrefabs.Count);
            Instantiate(potionsPrefabs[randomPotionIndex], potionsLocation[potionsLocationIndex]);
            potionsLocation.RemoveAt(potionsLocationIndex);
        }

        for (int i = 0; i < dungeonPassAmount; i++)
        {
            dungeonPassLocationIndex = Random.Range(0, dungeonPassLocation.Count);
            
            //Instantiate(dungeonPassPrefab, dungeonPassLocation[dungeonPassLocationIndex]);
            //potionsLocation.RemoveAt(dungeonPassLocationIndex);
        }
    }
}
