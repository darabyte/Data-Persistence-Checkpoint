using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public Text highScoreText;
    public InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + GameManager.instance.highScorerName + ": " + GameManager.instance.highScore;
    }

    public void StartButtonClick()
    {
        GameManager.instance.currentPlayerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClick()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

}
