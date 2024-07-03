using System;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
  public event Action<int> OnScoreChanged;

  private int _score;

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