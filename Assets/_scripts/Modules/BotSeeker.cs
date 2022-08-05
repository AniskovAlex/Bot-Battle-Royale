using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������ ���� ��� ������ ��������
/// </summary>
public class BotSeeker
{
    GameObject objectsHolder;

    public BotSeeker(GameObject objectsHolder)
    {
        this.objectsHolder = objectsHolder;
    }

    /// <summary>
    /// ���������� �������� ���� � ����������
    /// </summary>
    /// <param name="excluded">������ ��� ���������� �� ������</param>
    /// <returns></returns>
    public IDamageable SeekNewTarget(IDamageable excluded)
    {
        IDamageable[] objects = objectsHolder.GetComponentsInChildren<IDamageable>();
        if (objects.Length <= 1)
            return null;
        IDamageable founded = excluded;
        int index;
        while (founded == excluded) {
            index = Random.Range(0, objects.Length);
            founded = objects[index];
        }
        return founded;
    }
}
