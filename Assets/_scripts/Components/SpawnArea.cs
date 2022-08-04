using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Компонент для создание ботов
/// </summary>
public class SpawnArea : MonoBehaviour
{
    public GameObject botBody;
    GameObject botsList;
    Vector3 extents;

    private void Awake()
    {
        extents = gameObject.GetComponent<Renderer>().bounds.extents;
        botsList = gameObject.GetComponentInParent<AreasHolder>().botsHolder;
    }

    private void Start()
    {

    }
    /// <summary>
    /// Создание бота
    /// </summary>
    public void SpawnBot()
    {
        Vector3 spawnPoint = new Vector3
        {
            x = Random.Range(-extents.x, extents.x),
            y = 0,
            z = Random.Range(-extents.z, extents.z),
        };
        Vector3 worldPosition = gameObject.transform.position + spawnPoint;
        GameObject newBot = Instantiate(botBody, worldPosition, Quaternion.identity);
        newBot.gameObject.transform.SetParent(botsList.transform);
    }
}
