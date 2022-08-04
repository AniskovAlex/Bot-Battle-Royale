using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс-фасад бота
/// </summary>
public class Bot : MonoBehaviour
{
    BotData data;

    // Start is called before the first frame update
    void Start()
    {
        data = new BotData();
    }

}
