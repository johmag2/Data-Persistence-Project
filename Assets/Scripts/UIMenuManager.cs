using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuManager : MonoBehaviour
{

    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        MenuManager.Instance.LoadScore();
        UpdateText();    
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif       
    }

    public void StartNew()
    {
        if(nameInput.text == "")
        {
            MenuManager.Instance.sessionName = "Joe";
        }
        else
        {
            MenuManager.Instance.sessionName = nameInput.text;
        }

        SceneManager.LoadScene(1);
    }

    public void ViewScores()
    {
        SceneManager.LoadScene(2);
    }

    public void ResetScore()
    {
        MenuManager.Instance.ResetScore();
        UpdateText();
    }

    void UpdateText()
    {
        if(MenuManager.Instance != null)
        {
            scoreText.text = "Best Score: " + MenuManager.Instance.LoadName()[0] + ": " + MenuManager.Instance.LoadScore()[0];
        }
       
    }
}
