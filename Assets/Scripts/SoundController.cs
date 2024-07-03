using UnityEngine;

public class SoundController : MonoBehaviour
{
  public enum SoundType
  {
    Pin,
    Basket,
    None
  }
  
  public static SoundController Instance { get; private set; }

  [SerializeField]
  private AudioClip _pinHitSound;
  [SerializeField]
  private AudioClip _basketHitSound;
  [SerializeField]
  private float _fxVolume;

  private AudioSource _audioSource;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      _audioSource = gameObject.AddComponent<AudioSource>();
    } else
    {
      Destroy(gameObject);
    }
  }

  public void PlaySound(SoundType soundType)
  {
    if (soundType == SoundType.Basket)
    {
      _audioSource.PlayOneShot(_basketHitSound, _fxVolume);
    }else if (soundType == SoundType.Pin)
    {
      _audioSource.PlayOneShot(_pinHitSound, _fxVolume);
    }
  }
}