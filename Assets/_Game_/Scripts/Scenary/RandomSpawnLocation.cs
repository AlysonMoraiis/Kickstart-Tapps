using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnLocation : MonoBehaviour
{
    [Header("Potions")]
    [SerializeField]
    private GameObject atkPotionPrefab;
    [SerializeField]
    private GameObject lifePotionPrefab;
    [SerializeField]
    private Transform[] atkPotionLocation;
    [SerializeField]
    private Transform[] lifePotionLocation;
    [Header("Enemies")]
    [SerializeField]
    private GameObject mummyPrefab;
    [SerializeField]
    private GameObject skeletonPrefab;
    [SerializeField]
    private Transform[] mummyLocation;
    [SerializeField]
    private Transform[] skeletonLocation;

    private int locationIndex;

    private void Start()
    {
        Variation1_1();
    }
    private void Variation1_1()
    {
        locationIndex = Random.Range(0, mummyLocation.Length);
        //Instantiate(atkPotionPrefab[], atkPotionLocation);
        //Instantiate(lifePotionPrefab, lifePotionLocation);
        Instantiate(mummyPrefab, mummyLocation[locationIndex]);
        //int i = mummyLocation[locationIndex];
        Debug.Log(locationIndex);
    }
}
