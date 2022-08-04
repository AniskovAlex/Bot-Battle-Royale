using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Сущность бота
/// </summary>
public class Bot : MonoBehaviour, IDamageable
{
    BotData data;
    BotSeeker seeker;
    public BotFollower follower;

    NavMeshAgent agent;
    IDamageable target = null;
    public GameObject myself { get; set; }

    private void Awake()
    {
        myself = gameObject;
    }

    void Start()
    {
        GameObject objectsHolder = GetComponentInParent<ObjectsHolder>().gameObject;
        agent = GetComponent<NavMeshAgent>();

        data = new BotData();
        seeker = new BotSeeker(objectsHolder);

        target = seeker.SeekNewTarget(this);
        agent.stoppingDistance = 1.7f;
        follower.agent = agent;
        follower.FollowNewTarget(target.myself);
    }

    void Update()
    {
        if (data.health <= 0) return;
        if (target == null || target.GetHealth() <= 0)
        {
            target = seeker.SeekNewTarget(this);
            if (target != null)
                follower.FollowNewTarget(target.myself);
            else
                follower.FollowNewTarget(null);
            return;
        }
        if (agent.hasPath && agent.remainingDistance < 1.8f)
        {
            target.TakeDamage(data.damage * Time.deltaTime);
            if (target.GetHealth() <= 0)
            {
                target = seeker.SeekNewTarget(this);
                follower.FollowNewTarget(target.myself);
            }
        }
    }
    /// <summary>
    /// Вычитает из жизней бота урон
    /// </summary>
    /// <param name="damage">Урон</param>
    public void TakeDamage(float damage)
    {
        data.health -= damage;
        if (data.health <= 0)
            Destroy(myself);
    }


    /// <summary>
    /// Возвращает здоровье бота
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        return data.health;
    }

}
