using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText, mistakesText;
    public GameObject[] feedbackIndicators;
    private GameManager gameManagerScript;
    private BeatDetector beatDetectorScript;
    public int perfectScore, goodScore, badScore, badBeats, goodBeats, bankSize;
    private bool beatAttempt, canAttempt;

    // Start is called before the first frame update
    void Start()
    {
        beatDetectorScript = GameObject.Find("BeatDetector").GetComponent<BeatDetector>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //RESOLVE POINTS FOR BEAT OUTCOMES
    public void HitPerfectBeat(int points)
    {
        perfectScore += points;
        UpdateScoreText();
        goodBeats++;
        StartCoroutine(DisplayFeedback(0));
    }

    public void HitGoodBeat(int points)
    {
        goodScore += points;
        UpdateScoreText();
        goodBeats++;
        StartCoroutine(DisplayFeedback(1));
    }

    public void HitBadBeat(int points)
    {
        badScore += points;
        MarkMistakes();
        UpdateScoreText();
        badBeats++;
        StartCoroutine(DisplayFeedback(2));
        CheckGameOver();
    }
    public void HitMissedBeat(int points)
    {
        badScore += points;
        MarkMistakes();
        UpdateScoreText();
        badBeats++;
        StartCoroutine(DisplayFeedback(3));
        CheckGameOver();
    }

    //SECONDARY TASKS DURING SCORE UPDATES
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + (perfectScore + goodScore + badScore);
    }

    private void CheckGameOver()
    {
        if (badBeats >= 10)
        {
            //gameManagerScript.GameOver();
        }
    }

    IEnumerator DisplayFeedback(int feedback)
    {
        feedbackIndicators[feedback].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        feedbackIndicators[feedback].SetActive(false);
    }

    
    IEnumerator CheckDifficulty()
    {
        if (goodBeats >= 30)
        {
            BeatDetector.bpm += 10.0f;
            goodBeats = 0;
        }
        else yield return null;
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
