using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighscoreList : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scores;

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
            scores.text = MenuManager.Instance.LoadName() + ": " + MenuManager.Instance.LoadScore();
        }    
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
