using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Коробка, которая является целью бота
/// </summary>
public class Box : MonoBehaviour, IDamageable
{
    public float health;
    public GameObject myself { get; set; }

    private void Awake()
    {
        myself = gameObject;
    }

    private void Start()
    {
        health = 100f;
    }

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

    public float GetHealth()
    {
        return health;
    }
}
