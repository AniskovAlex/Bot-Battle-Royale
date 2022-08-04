using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Интерфейс объектов, которые могут получать урон
/// </summary>
public interface IDamageable
{
    GameObject myself { get; set; }
    void TakeDamage(float damage);
    float GetHealth();
}
