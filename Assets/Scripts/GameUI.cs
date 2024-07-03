using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI _scoreText;
  [SerializeField]
  private Button _resetScoreButton;
  [SerializeField]
  private Button _spawnBallButton;

  private void Awake()
  {
    _resetScoreButton.onClick.AddListener(OnResetButtonPressed);
    _spawnBallButton.onClick.AddListener(OnSpawnBallButtonPressed);
  }

  private void Start()
  {
    ScoreManager.Instance.OnScoreChanged += UpdateScore;
    UpdateScore(ScoreManager.Instance.GetScore());
  }

  private void UpdateScore(int score)
  {
    _scoreText.text = "Score: " + score;
  }

  private void OnResetButtonPressed()
  {
    ScoreManager.Instance.ResetScore();
    UpdateScore(0);
  }

  private void OnSpawnBallButtonPressed()
  {
    // Тут буде виклик функції для спавну м'ячика
    // BallSpawner.Instance.SpawnBall(); - приклад виклику
  }
}