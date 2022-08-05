using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// ������ ���� ��� ������������� ����
/// </summary>
public class BotFollower : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    
    GameObject target = null;

    /// <summary>
    /// ����� ����� ���� �������������
    /// </summary>
    /// <param name="target">����� ����</param>
    public void FollowNewTarget(GameObject target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target == null) return;
        if (agent.destination != target.transform.position)
            agent.SetDestination(target.transform.position);
    }
}
