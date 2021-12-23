using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI TextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var highScores = GameState.Instance.GetHighScores().OrderByDescending(h => h.Value).ToList();
        var y = -20;
        foreach (var highscore in highScores)
        {
            y -= 40;
            var text = Instantiate(TextPrefab, gameObject.transform);
            text.transform.Translate(0, y, 0);
            text.text = highscore.Key + ": " + highscore.Value;
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
