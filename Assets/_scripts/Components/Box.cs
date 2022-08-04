using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �������, ������� �������� ����� ����
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

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(myself);
        }         
    }

    public float GetHealth()
    {
        return health;
    }
}