using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
  [SerializeField]
  private Image _soundButtonImage;
  [SerializeField]
  private Sprite _soundOnSprite;
  [SerializeField]
  private Sprite _soundOffSprite;

  private Button _button;
  public Button Button => _button;

  private void Awake()
  {
    _button = GetComponent<Button>();
  }

  private void Start()
  {
    UpdateSoundButtonSprite();
  }

  public void UpdateSoundButtonSprite()
  {
    _soundButtonImage.sprite = SoundController.Instance.IsMuted() ? _soundOffSprite : _soundOnSprite;
  }
}