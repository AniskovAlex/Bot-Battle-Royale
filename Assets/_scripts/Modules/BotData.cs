using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// класс, который содержит характеристики бота
/// </summary>
public class BotData
{
    public float speed { get; set; }
    public float speedMultiplier = 1f;


    public float damage { get; set; }
    public float damageMultiplier = 0.2f;

    public float health { get; set; }
    public float healthMultiplier = 1f;

    public float points = 30;


    /// <summary>
    /// Конструктор, который случайным образом распределяет характеристики бота
    /// </summary>
    public BotData()
    {
        speed = 50;
        damage = 5;
        health = 50;

        float boost = Random.Range(0, points);
        speed += boost *speedMultiplier;
        points -= boost;

        boost = Random.Range(0, points);
        damage += boost * damageMultiplier;
        points -= boost;

        health += points * healthMultiplier;
    }

}
