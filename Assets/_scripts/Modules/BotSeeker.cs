using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Модуль бота для поиска объектов
/// </summary>
public class BotSeeker
{
    GameObject objectsHolder;

    public BotSeeker(GameObject objectsHolder)
    {
        this.objectsHolder = objectsHolder;
    }

    /// <summary>
    /// Возвращает найденую цель в контейнере
    /// </summary>
    /// <param name="excluded">Объект для исключения из поиска</param>
    /// <returns></returns>
    public IDamageable SeekNewTarget(IDamageable excluded)
    {
        IDamageable[] objects = objectsHolder.GetComponentsInChildren<IDamageable>();
        if (objects.Length <= 1)
            return null;
        IDamageable founded = excluded;
        int index;
        while (founded == excluded) {
            index = Random.Range(0, objects.Length);
            founded = objects[index];
        }
        return founded;
    }
}
