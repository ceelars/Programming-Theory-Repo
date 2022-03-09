using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DisplayLeaderboard : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI firstPlaceText, secondPlaceText, thirdPlaceText, fourthPlaceText, fifthPlaceText;

    private void Awake()
    {
        DisplayScores();
    }

    

    //Update score entry text
    private void DisplayScores()
    {
        firstPlaceText.text = GetScoreText(DataManager.firstPlaceName, DataManager.firstPlaceScore);
        secondPlaceText.text = GetScoreText(DataManager.secondPlaceName, DataManager.secondPlaceScore);
        thirdPlaceText.text = GetScoreText(DataManager.thirdPlaceName, DataManager.thirdPlaceScore);
        fourthPlaceText.text = GetScoreText(DataManager.fourthPlaceName, DataManager.fourthPlaceScore);
        fifthPlaceText.text = GetScoreText(DataManager.fifthPlaceName, DataManager.fifthPlaceScore);
    }

    //Return string of score entry
    private string GetScoreText(string name, int score)
    {
        return name + " - " + score;
    }

    // Update leaderboard when a score is beat
    public static void UpdateLeaderboard(int newScore)
    {
        if (newScore > DataManager.firstPlaceScore)
        {
            DataManager.fifthPlaceName = DataManager.fourthPlaceName;
            DataManager.fifthPlaceScore = DataManager.fourthPlaceScore;
            DataManager.fourthPlaceName = DataManager.thirdPlaceName;
            DataManager.fourthPlaceScore = DataManager.thirdPlaceScore;
            DataManager.thirdPlaceName = DataManager.secondPlaceName;
            DataManager.thirdPlaceScore = DataManager.secondPlaceScore;
            DataManager.secondPlaceName = DataManager.firstPlaceName;
            DataManager.secondPlaceScore = DataManager.firstPlaceScore;
            DataManager.firstPlaceName = DataManager.playerName;
            DataManager.firstPlaceScore = newScore;
        }
        else if (DataManager.firstPlaceScore >= newScore && newScore > DataManager.secondPlaceScore)
        {
            DataManager.fifthPlaceName = DataManager.fourthPlaceName;
            DataManager.fifthPlaceScore = DataManager.fourthPlaceScore;
            DataManager.fourthPlaceName = DataManager.thirdPlaceName;
            DataManager.fourthPlaceScore = DataManager.thirdPlaceScore;
            DataManager.thirdPlaceName = DataManager.secondPlaceName;
            DataManager.thirdPlaceScore = DataManager.secondPlaceScore;
            DataManager.secondPlaceName = DataManager.playerName;
            DataManager.secondPlaceScore = newScore;
        }
        else if (DataManager.secondPlaceScore >= newScore && newScore > DataManager.thirdPlaceScore)
        {
            DataManager.fifthPlaceName = DataManager.fourthPlaceName;
            DataManager.fifthPlaceScore = DataManager.fourthPlaceScore;
            DataManager.fourthPlaceName = DataManager.thirdPlaceName;
            DataManager.fourthPlaceScore = DataManager.thirdPlaceScore;
            DataManager.thirdPlaceName = DataManager.playerName;
            DataManager.thirdPlaceScore = newScore;
        }
        else if (DataManager.thirdPlaceScore >= newScore && newScore > DataManager.fourthPlaceScore)
        {
            DataManager.fifthPlaceName = DataManager.fourthPlaceName;
            DataManager.fifthPlaceScore = DataManager.fourthPlaceScore;
            DataManager.fourthPlaceName = DataManager.playerName;
            DataManager.fourthPlaceScore = newScore;
        }
        else if (DataManager.fourthPlaceScore >= newScore && newScore > DataManager.fifthPlaceScore)
        {
            DataManager.fifthPlaceName = DataManager.playerName;
            DataManager.fifthPlaceScore = newScore;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
