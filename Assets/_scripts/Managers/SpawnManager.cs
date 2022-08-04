using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Компонент, который контролирует где и сколько заспавниться объектов
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public GameObject areasHolder;
    public int botsCount;

    SpawnArea[] areasArr;

    void Start()
    {
        areasArr = areasHolder.GetComponentsInChildren<SpawnArea>();
        SpawnInAreas();
    }

    void SpawnInAreas()
    {
        int area;
        for (int i = 0; i < botsCount; i++)
        {
            area = Random.Range(0, areasArr.Length);
            areasArr[area].SpawnBot();
        }
    }
}
