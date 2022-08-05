using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Менеджер пула неииспользуемых ботов
/// </summary>
public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject pool;

    /// <summary>
    /// Возвращает объект бота из пула
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
    /// Перемещает бота в пул
    /// </summary>
    /// <param name="botBody">Перемещаемый бот</param>
    public void TransferBotInPool(GameObject botBody)
    {
        Bot bot = botBody.GetComponent<Bot>();
        if (bot == null) return;
        bot.gameObject.transform.SetParent(pool.transform);
        bot.transform.position = pool.transform.position;
        bot.GetComponent<Bot>().Deactivate();
    }
}
