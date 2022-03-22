using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameObject gameOverStatic;
    public GameObject gameOver;

    public static bool purpleOrbDestroyed, blueOrbDestroyed, greenOrbDestroyed, specialOrbDestroyed;
    public static int specialOrbDestroyedCount = 0;
    //ENCAPSULATION
    public static bool isGameActive { get; private set; }
    public static bool isGameOver { get; private set; }

    void Start()
    {
        isGameActive = true;
        gameOverStatic = gameOver;
    }

    private void Update()
    {
        if (specialOrbDestroyedCount == 3)
        {
            specialOrbDestroyed = false;
            specialOrbDestroyedCount = 0;
        }
    }

    public static void GameOver()
    {
        isGameActive = false;
        isGameOver = true;
        gameOverStatic.SetActive(true);
        SpawnManager.DestroyAllOrbs();
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(2);
    }
    public static void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void QuitGame()
    {
        DataManager.SaveDataToFile();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
