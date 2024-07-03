using UnityEngine;

public class SoundController : Singleton<SoundController>
{
  [SerializeField]
  private AudioClip _pinHitSound;
  [SerializeField]
  private AudioClip _basketHitSound;
  [SerializeField]
  private float _fxVolume;

  private AudioSource _audioSource;

  private void Awake()
  {
    _audioSource = gameObject.AddComponent<AudioSource>();
  }

  public void PlaySound(Enums.SoundType soundType)
  {
    if (soundType == Enums.SoundType.Basket)
    {
      _audioSource.PlayOneShot(_basketHitSound, _fxVolume);
    }else if (soundType == Enums.SoundType.Pin)
    {
      _audioSource.PlayOneShot(_pinHitSound, _fxVolume);
    }
  }
}