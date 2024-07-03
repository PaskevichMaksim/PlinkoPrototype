using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  public static ScoreManager Instance { get; private set; }

  public event Action<int> OnScoreChanged;

  private int _score;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    } else
    {
      Destroy(gameObject);
    }
  }

  public void AddPoints(int points)
  {
    _score += points;
    OnScoreChanged?.Invoke(_score);
  }

  public void ResetScore()
  {
    _score = 0;
    OnScoreChanged?.Invoke(_score);
  }
  
  public int GetScore()
  {
    return _score;
  }
}