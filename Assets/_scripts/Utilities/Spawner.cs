using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� ��� �������� � ���������� ��������
/// </summary>
static class Spawner
{
    /// <summary>
    /// ������� ������ � ����� � ���������� � ����������
    /// </summary>
    /// <param name="point">����� ������</param>
    /// <param name="body">������ ������</param>
    /// <param name="holder">���������</param>
    /// <returns></returns>
    public static GameObject SpawnBot(Vector3 point, GameObject body, GameObject holder)
    {
        GameObject newBot = GameObject.Instantiate(body, point, Quaternion.identity);
        newBot.gameObject.transform.SetParent(holder.transform);
        return newBot;
    }

    /// <summary>
    /// ����������� ���� � ����� � ���������� ��� � ����������
    /// </summary>
    /// <param name="point">����� ������</param>
    /// <param name="botBody">������ ����</param>
    /// <param name="botHolder">���������</param>
    public static void SpawnExistBot(Vector3 point, GameObject botBody, GameObject botHolder)
    {
        botBody.gameObject.transform.SetParent(botHolder.transform);
        botBody.transform.position = point;
        Bot bot = botBody.GetComponent<Bot>();
        bot.Activate();
        bot.ResetData();
    }
}
