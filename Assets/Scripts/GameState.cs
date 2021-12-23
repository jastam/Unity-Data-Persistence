using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    public string CurrentPlayerName = null;

    private Dictionary<string, int> HighScores = new Dictionary<string, int>();
    private string SaveFilePahtName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SaveFilePahtName = Application.persistentDataPath + "/savefile.json";
        LoadHighScores();
    }

    public void AddPlayer(string name)
    {
        if (!HighScores.ContainsKey(name))
        {
            HighScores.Add(name, 0);
        }

        SaveHighScores();
    }

    public void UpdatePlayerHighScore(string name, int score)
    {
        if (HighScores.ContainsKey(name) && score > HighScores[name])
        {
            HighScores[name] = score;
        }

        SaveHighScores();
    }

    public IEnumerable<string> GetPlayers()
    {
        return HighScores.Select(h => h.Key);
    }

    public int GetPlayerHighScore(string name)
    {
        return HighScores.FirstOrDefault(p => p.Key == name).Value;
    }

    public Dictionary<string, int> GetHighScores()
    {
        return HighScores;
    }

    private void SaveHighScores()
    {
        //string json = JsonUtility.ToJson(HighScores);
        string json = JsonConvert.SerializeObject(HighScores);
        File.WriteAllText(SaveFilePahtName, json);
    }

    private void LoadHighScores()
    {
        if (File.Exists(SaveFilePahtName))
        {
            string json = File.ReadAllText(SaveFilePahtName);
            //HighScores = JsonUtility.FromJson<Dictionary<string, int>>(json);
            HighScores = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
        }
    }

}
