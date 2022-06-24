using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public string currentPlayerName;
    public string highScorePlayerName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        loadOnStart();
    }

    [System.Serializable]
    public class HighScoreData
    {
        public int highScore;
        public string playerName;
    }

    public void saveOnQuit()
    {
        HighScoreData saveData = new HighScoreData();
        saveData.highScore = highScore;
        saveData.playerName = highScorePlayerName;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void loadOnStart()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData saveData = JsonUtility.FromJson<HighScoreData>(json);
            highScore = saveData.highScore;
            highScorePlayerName = saveData.playerName;
            currentPlayerName = saveData.playerName;
        }
    }
}
