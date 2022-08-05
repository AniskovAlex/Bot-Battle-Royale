using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �������, ������� �������� ����� ����
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
    /// ������� �������� ����
    /// </summary>
    /// <param name="damage">����</param>
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
    /// ���������� �������� �������
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        return health;
    }
}
