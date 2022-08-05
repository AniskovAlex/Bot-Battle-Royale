using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ёлемент таблицы лидеров содержащий место в таблице и счЄт
/// </summary>
public class ScoreboardElement : MonoBehaviour
{
    [SerializeField] Text place;
    [SerializeField] Text score;
    public Bot bot;

    /// <summary>
    /// »зменить подпись места в таблице
    /// </summary>
    /// <param name="newPlace"></param>
    public void ChangePlace(int newPlace)
    {
        place.text = newPlace.ToString();
    }

    /// <summary>
    /// изменить подпись счЄта в таблице
    /// </summary>
    /// <param name="newScore"></param>
    public void ChangeScore(int newScore)
    {
        score.text = newScore.ToString();
    }
}
