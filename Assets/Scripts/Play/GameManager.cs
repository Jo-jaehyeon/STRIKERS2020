using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public Text infoText;
    public Text ScoreText;

    public static int score = 0;
    public static int hp = 10;

    private int Savedscore = 0;
    private string keystring = "highScore";
    void Awake()
    {
        Savedscore = PlayerPrefs.GetInt(keystring, 0);
        ScoreText.text = "Best Score: " + Savedscore.ToString("000000");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "HP: " + hp.ToString("00");
        ScoreText.text = "Best Score: " + Savedscore.ToString("000000") + "\nScore: " + score.ToString("000000");
        if (score>Savedscore)
        {
            PlayerPrefs.SetInt(keystring, score);
        
        }
    }
}
