using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public TextMeshProUGUI perfectScoreText, goodScoreText, badScoreText;

    private GameManager gameManagerScript;
    private BeatDetector beatDetectorScript;
    public static List<BeatMarker> activeOrbs = new List<BeatMarker>();
    private int perfectScore, goodScore, badScore, badBeats, goodBeats;
    private bool beatAttempt, canAttempt;

    // Start is called before the first frame update
    void Start()
    {
        beatDetectorScript = GameObject.Find("BeatDetector").GetComponent<BeatDetector>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameActive)
        {
            CheckScore();
            CheckAttempt();
        }
    }
    //Register if input is played on the beat
    void CheckScore()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttempt &&
         (BeatDetector.beatCountD8 % 8 == 0 || BeatDetector.beatCountD8 % 8 == 0))
        {
            perfectScore++;
            //perfectScoreText.text = "Perfect: " + perfectScore;
            beatAttempt = true;
            canAttempt = false;
            DestroyOrb();
            //StartCoroutine(CheckDifficulty());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canAttempt && BeatDetector.beatCountD8 % 8 != 0 &&
            (BeatDetector.beatCountD8 % 8 <= 2 || BeatDetector.beatCountD8 % 8 >= 6))
        {
            goodScore++;
            //goodScoreText.text = "Good: " + goodScore;
            beatAttempt = true;
            canAttempt = false;
            DestroyOrb();
            //StartCoroutine(CheckDifficulty());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canAttempt &&
            (BeatDetector.beatCountD8 % 8 >= 2 || BeatDetector.beatCountD8 % 8 <= 6))
        {
            badScore++;
            //badScoreText.text = "Bad: " + badScore;
            beatAttempt = true;
            canAttempt = false;
            DestroyOrb();
            StartCoroutine(CheckGameOver());
        }
    }
    void CheckAttempt()
    {
        if (!beatAttempt && BeatDetector.beatCountD8 % 8 == 2 && BeatDetector.beatD8)
        {
            badScore++;
            //badScoreText.text = "Bad: " + badScore;
            beatAttempt = false;
            canAttempt = true;
            DestroyOrb();
            StartCoroutine(CheckGameOver());
        }
        else if (beatAttempt && BeatDetector.beatCountD8 % 8 == 2 && BeatDetector.beatD8)
        {
            beatAttempt = false;
            canAttempt = true;
        }
    }
    void DestroyOrb()
    {
        foreach(BeatMarker orb in activeOrbs)
        {
            if (orb != null)
            {
                orb.DestroySelf();
            }
        }
    }
    IEnumerator CheckGameOver()
    {
        badBeats ++;
        if (badBeats >= 10)
        {
            gameManagerScript.GameOver();
        }
        else yield return new WaitForSeconds(30.0f);
        badBeats--;
    }
    /*IEnumerator CheckDifficulty()
    {
        goodBeats++;
        if (goodBeats >= 30)
        {
            beatDetectorScript.BPM += 10.0f;
            goodBeats = 0;
        }
        else yield return null;
    }*/
}
