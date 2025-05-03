using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameManager gameManager;
    private float score = 0;

    private void DisplayScore()
    {
        if (score >= gameManager.GetMaxScore())
        {
            StartCoroutine(GameOver());
        }
        else
        {
            scoreText.text = score.ToString();
        }
    }

    public void IncrementScore()
    {
        score++;
        DisplayScore();
    }

    IEnumerator GameOver()
    {
        scoreText.text = score.ToString();
        yield return new WaitForSeconds(0.5f);
        gameManager.ResetLevel();
    }
}