using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject pool;

    public GameObject GetBotFromPool()
    {
        Bot bot = pool.GetComponentInChildren<Bot>();
        if (bot != null)
        {
            return bot.gameObject;
        }
        return null;
    }

    public void TransferBotInPool(GameObject botBody)
    {
        Bot bot = botBody.GetComponent<Bot>();
        if (bot == null) return;
        bot.gameObject.transform.SetParent(pool.transform);
        bot.transform.position = pool.transform.position;
        bot.GetComponent<Bot>().follower.enabled = false;
        bot.GetComponent<Bot>().agent.enabled =false;
        bot.GetComponent<Bot>().enabled = false;
    }
}
