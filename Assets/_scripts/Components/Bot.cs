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

    int score = 0;

    public BotDataShower dataShower;
    public BotFollower follower;

    public NavMeshAgent agent;
    IDamageable target = null;
    public GameObject myself { get; set; }

    public delegate void BotHandler(GameObject myself);
    public event BotHandler botDealth;

    private void Awake()
    {
        myself = gameObject;
    }

    void Start()
    {
        GameObject objectsHolder = GetComponentInParent<ObjectsHolder>().gameObject;

        data = new BotData();
        seeker = new BotSeeker(objectsHolder);

        target = seeker.SeekNewTarget(this);
        agent.stoppingDistance = 1.7f;
        agent.speed = data.speed;
        follower.FollowNewTarget(target.myself);
        dataShower.ChangeHealth(data.health);
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
            if (target.TakeDamage(data.damage * Time.deltaTime))
            {
                score++;
                dataShower.ChangeScore(score);
            }
            if (target.GetHealth() <= 0)
            {
                target = seeker.SeekNewTarget(this);
                if (target != null)
                    follower.FollowNewTarget(target.myself);
            }
        }
    }
    /// <summary>
    /// Вычитает из жизней бота урон
    /// </summary>
    /// <param name="damage">Урон</param>
    public bool TakeDamage(float damage)
    {
        data.health -= damage;
        if (data.health <= 0)
        {
            botDealth(myself);
            return true;
        }
        dataShower.ChangeHealth(data.health);
        return false;
    }


    /// <summary>
    /// Возвращает здоровье бота
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        return data.health;
    }

    public void ResetData()
    {
        score = 0;
        data = new BotData();
        agent.speed = data.speed;

        dataShower.ChangeHealth(data.health);
        dataShower.ChangeScore(score);
    }

}
