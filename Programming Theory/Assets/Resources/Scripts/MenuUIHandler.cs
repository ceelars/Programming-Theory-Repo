using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameEntry, colorChoice;
    private bool isNameEntered;
    private static bool isInMenu;
    public static bool isInMenuStatic
    {
        get { return isInMenu; }
    }

    public GameObject nameWarning;

    private void Start()
    {
        isInMenu = true;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
   
    public void GoToLeaderboard()
    {
        SceneManager.LoadScene(1);
        isInMenu = false;
    }
    public void GoToGame()
    {
        if(CheckForName())
        {
            SceneManager.LoadScene(2);
            isInMenu = false;
        }
        else
        {
            nameWarning.SetActive(false);
            nameWarning.SetActive(true);
        }
    }

    public void EnterName()
    {
        isNameEntered = true;
    }
    private bool CheckForName()
    {
        if (isNameEntered == true)
        {
            return true;
        }
        else
        {
            return false; ;
        }
    }
    //Save player name
    public void SubmitName()
    {
        DataManager.playerName = nameEntry.text;
    }

    //Save color selection
    public void SubmitColorPalette()
    {
        Color purpleOrb;
        Color blueOrb;
        Color greenOrb;

        if (colorChoice.text == "Default")
        {
            purpleOrb = new Color(179, 97, 255, 255);
            blueOrb = new Color(97, 133, 255, 255);
            greenOrb = new Color(97, 255, 208, 255);
            DataManager.SaveColorPalette(purpleOrb, blueOrb, greenOrb);
        }
        else if (colorChoice.text == "Neon")
        {
            purpleOrb = new Color(199, 36, 177, 255);
            blueOrb = new Color(77, 77, 255, 255);
            greenOrb = new Color(68, 214, 44, 255);
            DataManager.SaveColorPalette(purpleOrb, blueOrb, greenOrb);
        }
        else if (colorChoice.text == "Monochrome")
        {
            purpleOrb = new Color (227, 232, 234, 255);
            blueOrb = new Color (112, 122, 126, 255);
            greenOrb = new Color (188, 202, 208, 255);
            DataManager.SaveColorPalette(purpleOrb, blueOrb, greenOrb);
        }
        else if (colorChoice.text == "Pastel")
        {
            purpleOrb = new Color (218, 191, 222, 255);
            blueOrb = new Color (160, 196, 255, 255);
            greenOrb = new Color (202, 255, 191, 255);
            DataManager.SaveColorPalette(purpleOrb, blueOrb, greenOrb);
        }
        else if (colorChoice.text == "Sunrise")
        {
            purpleOrb = new Color (254, 213, 113, 255);
            blueOrb = new Color (183, 44, 60, 255);
            greenOrb = new Color (255, 140, 76, 255);
            DataManager.SaveColorPalette(purpleOrb, blueOrb, greenOrb);
        }
        else if (colorChoice.text == "Midnight")
        {
            purpleOrb = new Color (0, 40, 83, 255);
            blueOrb = new Color (81, 28, 81, 255);
            greenOrb = new Color (0, 70, 140, 255);
            DataManager.SaveColorPalette(purpleOrb, blueOrb, greenOrb);
        }
        else if (colorChoice.text == "Primary")
        {
            purpleOrb = new Color (255, 255, 0, 255);
            blueOrb = new Color (255, 0, 0, 255);
            greenOrb = new Color (0, 0, 255, 255);
            DataManager.SaveColorPalette(purpleOrb, blueOrb, greenOrb);
        }
        else if (colorChoice.text == "Secondary")
        {
            purpleOrb = new Color (255, 139, 0, 255);
            blueOrb = new Color (139, 0, 116, 255);
            greenOrb = new Color (0, 145, 0, 255);
            DataManager.SaveColorPalette(purpleOrb, blueOrb, greenOrb);
        }
    }
}
