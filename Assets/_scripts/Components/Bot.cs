using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Сущность бота
/// </summary>
public class Bot : MonoBehaviour, IDamageable
{
    [SerializeField] BotDataShower dataShower;
    [SerializeField] BotFollower follower;
    [SerializeField] NavMeshAgent agent;
  
    public GameObject myself { get; set; }
    public delegate void BotHandler(GameObject myself);
    public event BotHandler botDealth;
    public event BotHandler botGetScore;

    int score = 0;
    BotData data;
    BotSeeker seeker;
    IDamageable target = null;
    

    void Awake()
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
        dataShower.ChangeDamage(data.damage);
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
                botGetScore(myself);
                
                if (target.myself.GetComponent<Bot>() != null)
                {
                    data.IncreaseDamage(5f);
                    dataShower.ChangeDamage(data.damage);
                }
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

    /// <summary>
    /// Возвращает текущий счёт бота
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// Переопределяет параметры бота
    /// </summary>
    public void ResetData()
    {
        data = new BotData();
        agent.speed = data.speed;
        score = 0;

        dataShower.ChangeHealth(data.health);
        dataShower.ChangeScore(score);
        dataShower.ChangeDamage(data.damage);
    }

    public void Deactivate()
    {
        follower.enabled = false;
        agent.enabled = false;
        enabled = false;
    }

    public void Activate()
    {
        enabled = true;
        follower.enabled = true;
        agent.enabled = true;
    }
}
