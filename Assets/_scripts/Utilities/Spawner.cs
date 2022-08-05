using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Spawner
{
    public static GameObject SpawnBot(Vector3 point, GameObject botBody, GameObject botHolder)
    {
        GameObject newBot = GameObject.Instantiate(botBody, point, Quaternion.identity);
        newBot.gameObject.transform.SetParent(botHolder.transform);
        return newBot;
    }
}
