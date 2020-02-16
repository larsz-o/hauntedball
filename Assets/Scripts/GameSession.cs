using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
  int playerScore = 0;
    void Awake()
    {
        int sessions = FindObjectsOfType<GameSession>().Length;
        if (sessions > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return playerScore;
    }
    public void AddToScore(int points)
    {
        playerScore += points;
    }
    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
