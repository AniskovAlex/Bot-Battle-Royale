using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Модуль бота для преследования цели
/// </summary>
public class BotFollower : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    
    GameObject target = null;

    /// <summary>
    /// Задаёт новую цель преследования
    /// </summary>
    /// <param name="target">Новая цель</param>
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
