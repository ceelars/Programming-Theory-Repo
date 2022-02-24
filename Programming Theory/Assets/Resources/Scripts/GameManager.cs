using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public TextMeshProUGUI gameOver;
    public static bool isGameActive, isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GameOver()
    {
        isGameActive = false;
        isGameOver = true;
        //gameOver.gameObject.SetActive(true);

    }
}
