using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    public int Score { get => score; 
        set
        {
            score = value;
            scoreText.text = "x" + score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
