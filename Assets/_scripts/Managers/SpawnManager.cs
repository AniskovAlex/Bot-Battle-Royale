using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���������, ������� ������������ ��� � ������� ������������ ��������
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public GameObject areasHolder;
    public GameObject botHolder;
    public GameObject botBody;
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
            areasArr[area].SpawnBot(botBody, botHolder);
        }
    }

    public void SpawnAtPoint(Vector3 point)
    {
        Spawner.SpawnBot(point, botBody, botHolder);
    }
}
