using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public void Start()
    {
        if (SaveManager.Instance.highScorePlayerName != "")
        {
            Text.text = "Best Score - " + SaveManager.Instance.highScorePlayerName + " - " + SaveManager.Instance.highScore;
        }
        else
        {
            Text.text = "You're the first player !";
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        SaveManager.Instance.saveOnQuit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void NameEdit(string newName)
    {
        SaveManager.Instance.currentPlayerName = newName;
    }
}
