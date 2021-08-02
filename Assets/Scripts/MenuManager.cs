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
    [SerializeField] int[] sortingNumbers = new int[5];
    [SerializeField] string[] sortingNames = new string[5];
    string[] defNames = new string[5];
    int[] defScores = new int[5];

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

        public int[] highScore = new int[5];
        public string[] highNames = new string[5];
       
    }

    public void SaveScore(int score)
    {

        string path = Application.persistentDataPath + "/savefile.json";

        string json = File.ReadAllText(path);
        HighScore data = JsonUtility.FromJson<HighScore>(json);

    
        InsertInArray(data.highScore, data.highNames, score, MenuManager.Instance.sessionName);
        data.highScore = sortingNumbers;
        data.highNames = sortingNames;

        json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public int[] LoadScore()
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
            for (int i = 0; i < defScores.Length; i++)
            {
                defScores[i] = 0;
            }

            return defScores;
        }
        
    }

    public string[] LoadName()
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
            for (int i = 0; i < defNames.Length; i++)
            {
                defNames[i] = "Joe";
            }

            return defNames;
        }

    }

    public void ResetScore()
    {
        HighScore data = new HighScore();
        
        for(int i = 0; i < data.highScore.Length; i++)
        {
            data.highScore[i] = 0;
            data.highNames[i] = "Joe";
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void InsertInArray(int[] numbers, string[] names, int newNumber, string newName)
    {

        for (int i = 0; i < numbers.Length; i++)
        {
            if (newNumber > numbers[i])
            {
                int newIndex = i;

                for (int j = numbers.Length-1; j > newIndex; j--)
                {

                    numbers[j] = numbers[j-1];
                    names[j] = names[j-1];
                }

                numbers[newIndex] = newNumber;
                names[newIndex] = newName;

                break;
            }
        }

        sortingNames = names;
        sortingNumbers = numbers;
    }

}
