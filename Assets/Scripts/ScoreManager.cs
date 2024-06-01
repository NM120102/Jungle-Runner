using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float pointPerSecond;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;

    public float score;
    private float hiScore;

    public bool isScoreIncreasing;
    void Start()
    {
        isScoreIncreasing = true;

        if (PlayerPrefs.HasKey("HiScore"))
        {
            hiScore = PlayerPrefs.GetFloat("HiScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoreIncreasing)
            score += pointPerSecond * Time.deltaTime;

        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
        }

        scoreText.text = Mathf.Round(score).ToString();
        hiScoreText.text = Mathf.Round(hiScore).ToString();
    }
}
