using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �������� ���� ��������������� �����
/// </summary>
public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject pool;

    /// <summary>
    /// ���������� ������ ���� �� ����
    /// </summary>
    /// <returns></returns>
    public GameObject GetBotFromPool()
    {
        Bot bot = pool.GetComponentInChildren<Bot>();
        if (bot != null)
        {
            return bot.gameObject;
        }
        return null;
    }

    /// <summary>
    /// ���������� ���� � ���
    /// </summary>
    /// <param name="botBody">������������ ���</param>
    public void TransferBotInPool(GameObject botBody)
    {
        Bot bot = botBody.GetComponent<Bot>();
        if (bot == null) return;
        bot.gameObject.transform.SetParent(pool.transform);
        bot.transform.position = pool.transform.position;
        bot.GetComponent<Bot>().Deactivate();
    }
}
