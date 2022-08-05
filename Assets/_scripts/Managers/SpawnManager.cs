using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������, ������� ������������ ��� � ������� ������������ ��������
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject areasHolder;
    [SerializeField] GameObject botHolder;
    [SerializeField] GameObject botBody;
    [SerializeField] PoolManager pool;
    [SerializeField] ScoreboardManager scoreboard;
    [SerializeField] int botsCount;

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
            GameObject newBot = areasArr[area].SpawnBot(botBody, botHolder);
            SetBotsPool(newBot);
            scoreboard.AddNewBotToBoard(newBot.GetComponent<Bot>());
        }
    }

    /// <summary>
    /// ����� �� ���� ��� ���������� ���� � �����
    /// </summary>
    /// <param name="point">����� ������</param>
    public void SpawnAtPoint(Vector3 point)
    {
        GameObject botFromPool = pool.GetBotFromPool();
        if (botFromPool != null)
        {
            Spawner.SpawnExistBot(point, botFromPool, botHolder);
            scoreboard.ChangePlace(botFromPool);
        }
        else
        {
            GameObject newBot = Spawner.SpawnBot(point, botBody, botHolder);
            SetBotsPool(newBot);
            scoreboard.AddNewBotToBoard(newBot.GetComponent<Bot>());
        }
    }

    void SetBotsPool(GameObject bot)
    {
        bot.GetComponent<Bot>().botDealth += pool.TransferBotInPool;
    }
}
