using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText, mistakesText, playerNameText;
    public GameObject[] feedbackIndicators;
    public int currentScore, perfectScore, goodScore, badScore, badBeats, goodBeats, bankSize;

    private void Awake()
    {
        playerNameText.text = DataManager.playerName;
    }
    //RESOLVE POINTS FOR BEAT OUTCOMES
    public void HitPerfectBeat(int points)
    {
        perfectScore += points;
        UpdateScore();
        goodBeats++;
        StartCoroutine(DisplayFeedback(0));
    }

    public void HitGoodBeat(int points)
    {
        goodScore += points;
        UpdateScore();
        goodBeats++;
        StartCoroutine(DisplayFeedback(1));
    }

    public void HitBadBeat(int points)
    {
        badScore += points;
        MarkMistakes();
        UpdateScore();
        badBeats++;
        StartCoroutine(DisplayFeedback(2));
        CheckGameOver();
    }
    public void HitMissedBeat(int points)
    {
        badScore += points;
        MarkMistakes();
        UpdateScore();
        badBeats++;
        StartCoroutine(DisplayFeedback(3));
        CheckGameOver();
    }

    //SECONDARY TASKS DURING SCORE UPDATES
    private void UpdateScore()
    {
        currentScore = (perfectScore + goodScore + badScore);
        scoreText.text = "Score: " + currentScore;
    }

    private void CheckGameOver()
    {
        if (badBeats >= 10)
        {
            GameManager.GameOver();
            DisplayLeaderboard.UpdateLeaderboard(currentScore);
            DataManager.SaveScores();
            SpawnManager.DestroyAllOrbs();
        }
    }

    IEnumerator DisplayFeedback(int feedback)
    {
        feedbackIndicators[feedback].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        feedbackIndicators[feedback].SetActive(false);
    }

    
    private void CheckDifficulty()
    {
        if (goodBeats >= 30)
        {
            BeatDetector.bpm += 10.0f;
            goodBeats = 0;
        }
    }
    private void MarkMistakes()
    {
        mistakesText.text = "Mistakes: ";

        for (int i = 0; i<= badBeats; i++)
        {
            mistakesText.text += "X";
        }
    }
}
