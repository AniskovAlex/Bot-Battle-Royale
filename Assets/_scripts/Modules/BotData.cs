using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �����, ������� �������� �������������� ����
/// </summary>
public class BotData
{
    [SerializeField] float speedMultiplier = 0.1f;
    [SerializeField] float damageMultiplier = 0.5f;
    [SerializeField] float healthMultiplier = 2f;
    [SerializeField] float points = 30;

    public float speed { get; private set; }
    public float damage { get; private set; }
    public float health
    {
        get => currentHealth;
        set
        {
            if (currentHealth > 0)
                currentHealth = value;
        }
    }

    float currentHealth = 1;

    /// <summary>
    /// �����������, ������� ��������� ������� ������������ �������������� ����
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

    /// <summary>
    /// ����������� ���� ����
    /// </summary>
    /// <param name="damageAdd">���������� ����</param>
    public void IncreaseDamage(float damageAdd)
    {
        damage = Mathf.Clamp(damage + damageAdd, 0, 100);
    }
}
