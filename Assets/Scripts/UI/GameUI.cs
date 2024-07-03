using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI _scoreText;
  [SerializeField]
  private Button _resetScoreButton;
  [SerializeField]
  private Button _spawnBallButton;
  [FormerlySerializedAs("_soundToggleButtonButton"),SerializeField]
  private SoundButton _soundButtonButton;

  private void Awake()
  {
    _resetScoreButton.onClick.AddListener(OnResetButtonPressed);
    _spawnBallButton.onClick.AddListener(OnSpawnBallButtonPressed);
    _soundButtonButton.Button.onClick.AddListener(OnToggleSoundButtonPressed);
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
   BallSpawner.Instance.SpawnBall();
  }
  private void OnToggleSoundButtonPressed()
  {
    SoundController.Instance.ToggleMute();
    _soundButtonButton.UpdateSoundButtonSprite();
  }
}