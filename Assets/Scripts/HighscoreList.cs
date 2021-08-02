using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighscoreList : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoresText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateList()
    {
        if(MenuManager.Instance != null)
        {
            string[] names = MenuManager.Instance.LoadName();
            int[] scores = MenuManager.Instance.LoadScore();

            for(int i = 0; i < scores.Length; i++)
            {
                scoresText.text += names[i] + ": " + scores[i] + "\n";
            }
            
        }    
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
