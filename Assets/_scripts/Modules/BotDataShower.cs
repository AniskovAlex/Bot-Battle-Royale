using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Модуль вывода параметров бота
/// </summary>
public class BotDataShower : MonoBehaviour
{
    [SerializeField] Text scoreField;
    [SerializeField] Text healthField;
    [SerializeField] Text damageField;

    /// <summary>
    /// Изменить надпись счёта
    /// </summary>
    /// <param name="score">Значение счёта</param>
    public void ChangeScore(int score)
    {
        scoreField.text = "Счёт: " + score; 
    }

    /// <summary>
    /// Изменить надпись здоровья
    /// </summary>
    /// <param name="health">Значение здоровья</param>
    public void ChangeHealth(float health)
    {
        healthField.text = "ХП: " + Mathf.CeilToInt(health);
    }

    /// <summary>
    /// Изменить надпись урона
    /// </summary>
    /// <param name="damage">Значение урона</param>
    public void ChangeDamage(float damage)
    {
        damageField.text = "Урон: " + Mathf.CeilToInt(damage);
    }
}
