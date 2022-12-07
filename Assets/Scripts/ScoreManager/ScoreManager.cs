using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int playerScore;

    [SerializeField] private int WinningScore;
    [SerializeField] private GameObject _WinCanvas;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    public void ScoreOnChange(int deltaScore)
    {
        playerScore += deltaScore;
        Debug.Log("SCORE: " + playerScore);
        if(playerScore == WinningScore)
        {
            _WinCanvas.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public int GetScore { get { return playerScore; } }
}
