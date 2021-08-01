using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.EventSystems;




public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string sessionName;


    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return; 
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class HighScore
    {
        public int highScore;
        public string highNames;
    }

    public void SaveScore(int score)
    {
        HighScore data = new HighScore();
        data.highScore = score;
        data.highNames = MenuManager.Instance.sessionName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public int LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);

            return data.highScore;
        }
        else
        {
            return 0;
        }

    }

    public string LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);

            return data.highNames;
            
        }
        else
        {
            return "Joe";
        }

    }

    public void ResetScore()
    {
        HighScore data = new HighScore();
        data.highScore = 0;
        data.highNames = "Joe";

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

}
