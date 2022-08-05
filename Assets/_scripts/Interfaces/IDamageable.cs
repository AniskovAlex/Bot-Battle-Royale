using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������� ��������, ������� ����� �������� ����
/// </summary>
public interface IDamageable
{
    GameObject myself { get; set; }
    bool TakeDamage(float damage);
    float GetHealth();
}
