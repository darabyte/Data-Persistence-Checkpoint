using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int highScore = 0;
    public string highScorerName;
    public string currentPlayerName;

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;

            // Load high score
            string path = Application.persistentDataPath + "SaveData.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData saveData = JsonUtility.FromJson<SaveData>(json);
                highScore = saveData.highScore;
                highScorerName = saveData.highScorerName;
            }
            else
            {
                highScorerName = "Nobody";
            }
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHighScore(int points)
    {
        if (points > highScore)
        {
            highScore = points;
            highScorerName = currentPlayerName;

            SaveData saveData = new SaveData();
            saveData.highScore = highScore;
            saveData.highScorerName = highScorerName;
            string json;
            json = JsonUtility.ToJson(saveData);
            File.WriteAllText(Application.persistentDataPath + "SaveData.json", json);

        }
    }

    [System.Serializable]
    private class SaveData
    {
        public int highScore;
        public string highScorerName;
    }

}
