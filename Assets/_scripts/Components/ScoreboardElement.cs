using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������� ������� ������� ���������� ����� � ������� � ����
/// </summary>
public class ScoreboardElement : MonoBehaviour
{
    [SerializeField] Text place;
    [SerializeField] Text score;
    public Bot bot;

    /// <summary>
    /// �������� ������� ����� � �������
    /// </summary>
    /// <param name="newPlace"></param>
    public void ChangePlace(int newPlace)
    {
        place.text = newPlace.ToString();
    }

    /// <summary>
    /// �������� ������� ����� � �������
    /// </summary>
    /// <param name="newScore"></param>
    public void ChangeScore(int newScore)
    {
        score.text = newScore.ToString();
    }
}
