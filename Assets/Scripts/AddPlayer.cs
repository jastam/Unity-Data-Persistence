using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddPlayer : MonoBehaviour
{
    [SerializeField] private TMP_InputField Name;

    public void Add()
    {
        if (!string.IsNullOrEmpty(Name.text))
        {
            GameState.Instance.AddPlayer(Name.text);
            SceneManager.LoadScene(0);
        }
    }

    public void Cancel()
    {
        SceneManager.LoadScene(0);
    }

}
