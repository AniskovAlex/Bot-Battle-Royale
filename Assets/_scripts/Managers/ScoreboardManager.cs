using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    [SerializeField] GameObject element;
    [SerializeField] GameObject content;
    [SerializeField] GameObject panel;

    public void ShowPanel()
    {
        panel.active = !panel.active;
    }

    public void AddNewBotToBoard(Bot bot)
    {
        ScoreboardElement[] elements = content.GetComponentsInChildren<ScoreboardElement>();
        GameObject newElementBody = Instantiate(element, content.transform);
        ScoreboardElement newElement = newElementBody.GetComponent<ScoreboardElement>();
        if (newElement == null) return;
        newElement.ChangeScore(bot.GetScore());
        newElement.ChangePlace(elements.Length + 1);
        newElement.bot = bot;
        bot.botGetScore += ChangePlace;
    }

    public void ChangePlace(GameObject bot)
    {
        ScoreboardElement[] elements = content.GetComponentsInChildren<ScoreboardElement>();
        Bot currentBot = bot.GetComponent<Bot>();
        if (currentBot == null) return;
        int index = 0;
        foreach (ScoreboardElement x in elements)
        {
            if (x.bot == currentBot) break;
            index++;
        }

        ChoosePlace(index, elements[index], elements);
        elements = content.GetComponentsInChildren<ScoreboardElement>();
        index = 1;
        foreach (ScoreboardElement x in elements)
        {
            x.ChangePlace(index);
            x.ChangeScore(x.bot.GetScore());
            index++;
        }

    }
    void ChoosePlace(int index, ScoreboardElement currentElement, ScoreboardElement[] elements)
    {
        if (index < elements.Length - 1)
        {
            if (currentElement.bot.GetScore() < elements[index + 1].bot.GetScore())
            {
                for (int i = index + 2; i < elements.Length; i++)
                    if (currentElement.bot.GetScore() >= elements[i].bot.GetScore())
                    {
                        currentElement.gameObject.transform.SetSiblingIndex(i - 1);
                        return;
                    }
                currentElement.gameObject.transform.SetSiblingIndex(elements.Length - 1);
            }
        }
        if (index > 0)
            if (currentElement.bot.GetScore() > elements[index - 1].bot.GetScore())
            {
                for (int i = index - 2; i >= 0; i--)
                    if (currentElement.bot.GetScore() <= elements[i].bot.GetScore())
                    {
                        currentElement.gameObject.transform.SetSiblingIndex(i + 1);
                        return;
                    }
                currentElement.gameObject.transform.SetSiblingIndex(0);
            }


    }
}


