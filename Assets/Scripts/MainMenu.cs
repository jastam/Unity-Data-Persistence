using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown Players;

    void Start()
    {
        var players = GameState.Instance.GetPlayers();
        foreach (string player in players)
        {
            Players.options.Add(new TMP_Dropdown.OptionData(player));
        }
    }

    public void HighScores()
    {
        SceneManager.LoadScene(1);
    }

    public void AddPlayer()
    {
        SceneManager.LoadScene(2);
    }

    public void Play()
    {
        GameState.Instance.CurrentPlayerName = Players.options[Players.value].text;
        SceneManager.LoadScene(3);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

}
