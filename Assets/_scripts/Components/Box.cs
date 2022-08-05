using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Коробка, которая является целью бота
/// </summary>
public class Box : MonoBehaviour, IDamageable
{
    [SerializeField] float health;
    public GameObject myself { get; set; }

    private void Awake()
    {
        myself = gameObject;
    }

    /// <summary>
    /// Коробка получает урон
    /// </summary>
    /// <param name="damage">Урон</param>
    /// <returns></returns>
    public bool TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(myself);
            return true;
        }
        return false;
    }


    /// <summary>
    /// Возвращает здоровье коробки
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        return health;
    }
}
