using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public static string playerName, firstPlaceName, secondPlaceName, thirdPlaceName, fourthPlaceName, fifthPlaceName;
    public static int firstPlaceScore, secondPlaceScore, thirdPlaceScore, fourthPlaceScore, fifthPlaceScore;
    private static Dictionary<string, Color> colorPalette = new Dictionary<string, Color>
    { //DEFAULT COLOR
        {"Purple", new Color(179, 97, 255, 255) },
        {"Blue", new Color(97, 133, 255, 255) },
        {"Green", new Color(97, 255, 208, 255) }
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadDataFromFile();
    }

    private void Awake()
    {
        Singleton();
    }

    //Create single instance of this object
    void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //Save chosen color selection
    public static void SaveColorPalette(Color purpleOrb, Color blueOrb, Color greenOrb)
    {
        colorPalette["Purple"] = purpleOrb;
        colorPalette["Blue"] = blueOrb;
        colorPalette["Green"] = greenOrb;
    }

    public static Color GetColor(string orbSelection)
    {
        if (orbSelection == "Purple")
        {
            return colorPalette["Purple"];
        }
        else if (orbSelection == "Blue")
        {
            return colorPalette["Blue"];
        }
        else if (orbSelection == "Green")
        {
            return colorPalette["Green"];
        }
        else return colorPalette["Green"];
    }

    //SAVE DATA BETWEEN SESSIONS
    [System.Serializable]
    class SaveData
    {
        public string firstPlaceName, secondPlaceName, thirdPlaceName, fourthPlaceName, fifthPlaceName;
        public int firstPlaceScore, secondPlaceScore, thirdPlaceScore, fourthPlaceScore, fifthPlaceScore;
        public List<Color> colorPalette = new List<Color>
        { //DEFAULT COLOR
            {new Color(179, 97, 255, 255) },
            {new Color(97, 133, 255, 255) },
            {new Color(97, 255, 208, 255) }
        };
    }

    public static void SaveDataToFile()
    {
        SaveData data = new SaveData();
        SaveScores(data);
        SaveColorPaletteToData(data);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    private static void SaveScores(SaveData data)
    {
        data.firstPlaceName = firstPlaceName;
        data.firstPlaceScore = firstPlaceScore;

        data.secondPlaceName = secondPlaceName;
        data.secondPlaceScore = secondPlaceScore;

        data.thirdPlaceName = thirdPlaceName;
        data.thirdPlaceScore = thirdPlaceScore;

        data.fourthPlaceName = fourthPlaceName;
        data.fourthPlaceScore = fourthPlaceScore;

        data.fifthPlaceName = fifthPlaceName;
        data.fifthPlaceScore = fifthPlaceScore;
    }

    private static void SaveColorPaletteToData(SaveData data)
    {
        data.colorPalette[0] = colorPalette["Purple"];
        data.colorPalette[1] = colorPalette["Blue"];
        data.colorPalette[2] = colorPalette["Green"];
    }

    private void LoadDataFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            LoadScores(data);
            LoadColorPaletteFromData(data);
        }
    }
    private void LoadScores(SaveData data)
    {
        firstPlaceName = data.firstPlaceName;
        firstPlaceScore = data.firstPlaceScore;

        secondPlaceName = data.secondPlaceName;
        secondPlaceScore = data.secondPlaceScore;

        thirdPlaceName = data.thirdPlaceName;
        thirdPlaceScore = data.thirdPlaceScore;

        fourthPlaceName = data.fourthPlaceName;
        fourthPlaceScore = data.fourthPlaceScore;

        fifthPlaceName = data.fifthPlaceName;
        fifthPlaceScore = data.fifthPlaceScore;
    }
    
    private void LoadColorPaletteFromData(SaveData data)
    {
        colorPalette["Purple"] = data.colorPalette[0];
        colorPalette["Blue"] = data.colorPalette[1];
        colorPalette["Green"] = data.colorPalette[2];
    }
}
