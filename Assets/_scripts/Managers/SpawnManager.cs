using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Компонент, который контролирует где и сколько заспавниться объектов
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public GameObject areasHolder;
    public GameObject botHolder;
    public GameObject botBody;
    public PoolManager pool;
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
            SetBotsPool(areasArr[area].SpawnBot(botBody, botHolder));

        }
    }

    public void SpawnAtPoint(Vector3 point)
    {
        GameObject botFromPool = pool.GetBotFromPool();
        if (botFromPool != null)
            Spawner.SpawnExistBot(point, botFromPool, botHolder);
        else
            SetBotsPool(Spawner.SpawnBot(point, botBody, botHolder));
    }

    void SetBotsPool(GameObject bot)
    {
        bot.GetComponent<Bot>().botDealth += pool.TransferBotInPool;
    }
}
