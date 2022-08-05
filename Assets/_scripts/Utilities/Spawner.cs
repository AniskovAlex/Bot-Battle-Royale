using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Утилита для создания и размещения объектов
/// </summary>
static class Spawner
{
    /// <summary>
    /// Создать объект в точке и размещение в контейнере
    /// </summary>
    /// <param name="point">Точка спавна</param>
    /// <param name="body">Объект спавна</param>
    /// <param name="holder">Контейнер</param>
    /// <returns></returns>
    public static GameObject SpawnBot(Vector3 point, GameObject body, GameObject holder)
    {
        GameObject newBot = GameObject.Instantiate(body, point, Quaternion.identity);
        newBot.gameObject.transform.SetParent(holder.transform);
        return newBot;
    }

    /// <summary>
    /// Переместить бота в точку и разместить его в контейнере
    /// </summary>
    /// <param name="point">Точка спавна</param>
    /// <param name="botBody">Объект бота</param>
    /// <param name="botHolder">Контейнер</param>
    public static void SpawnExistBot(Vector3 point, GameObject botBody, GameObject botHolder)
    {
        botBody.gameObject.transform.SetParent(botHolder.transform);
        botBody.transform.position = point;
        Bot bot = botBody.GetComponent<Bot>();
        bot.Activate();
        bot.ResetData();
    }
}
