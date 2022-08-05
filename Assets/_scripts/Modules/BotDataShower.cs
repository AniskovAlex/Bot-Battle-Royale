using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������ ������ ���������� ����
/// </summary>
public class BotDataShower : MonoBehaviour
{
    [SerializeField] Text scoreField;
    [SerializeField] Text healthField;
    [SerializeField] Text damageField;

    /// <summary>
    /// �������� ������� �����
    /// </summary>
    /// <param name="score">�������� �����</param>
    public void ChangeScore(int score)
    {
        scoreField.text = "����: " + score; 
    }

    /// <summary>
    /// �������� ������� ��������
    /// </summary>
    /// <param name="health">�������� ��������</param>
    public void ChangeHealth(float health)
    {
        healthField.text = "��: " + Mathf.CeilToInt(health);
    }

    /// <summary>
    /// �������� ������� �����
    /// </summary>
    /// <param name="damage">�������� �����</param>
    public void ChangeDamage(float damage)
    {
        damageField.text = "����: " + Mathf.CeilToInt(damage);
    }
}
