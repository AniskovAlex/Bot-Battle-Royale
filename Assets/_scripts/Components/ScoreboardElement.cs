using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardElement : MonoBehaviour
{
    [SerializeField] Text place;
    [SerializeField] Text score;
    public Bot bot;

    public void ChangePlace(int newPlace)
    {
        place.text = newPlace.ToString();
    }

    public void ChangeScore(int newScore)
    {
        score.text = newScore.ToString();
    }
}
