using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotDataShower : MonoBehaviour
{
    public Text scoreField;
    public Text healthField;

    public void ChangeScore(int score)
    {
        scoreField.text = "����: " + score; 
    }

    public void ChangeHealth(float health)
    {
        healthField.text = "��: " + Mathf.CeilToInt(health);
    }
}
