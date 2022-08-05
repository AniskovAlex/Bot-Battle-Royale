using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// класс, который содержит характеристики бота
/// </summary>
public class BotData
{
    public float speed { get; private set; }
    public float speedMultiplier = 0.1f;


    public float damage { get; private set; }
    public float damageMultiplier = 0.5f;

    float currentHealth = 1;

    public float health
    {
        get => currentHealth;
        set
        {
            if (currentHealth > 0)
                currentHealth = value;
        }
    }
    public float healthMultiplier = 2f;

    public float points = 30;


    /// <summary>
    /// Конструктор, который случайным образом распределяет характеристики бота
    /// </summary>
    public BotData()
    {
        speed = 2;
        damage = 10;
        health = 50;

        float boost = Random.Range(0, points);
        speed += boost * speedMultiplier;
        points -= boost;

        boost = Random.Range(0, points);
        damage += boost * damageMultiplier;
        points -= boost;

        health += points * healthMultiplier;
    }


    public void IncreaseDamage(float damageAdd)
    {
        damage = Mathf.Clamp(damage + damageAdd, 0, 100);
    }
}
