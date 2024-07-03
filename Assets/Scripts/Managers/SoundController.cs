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
  private bool _isMuted = false;

  private void Awake()
  {
    _audioSource = gameObject.AddComponent<AudioSource>();
  }

  public void PlaySound (Enums.SoundType soundType)
  {
    if (_isMuted)
    {
      return;
    }

    switch (soundType)
    {
      case Enums.SoundType.Pin:
        _audioSource.PlayOneShot(_pinHitSound, _fxVolume);
        break;
      case Enums.SoundType.Basket:
        _audioSource.PlayOneShot(_basketHitSound, _fxVolume);
        break;
    }
  }

  public void ToggleMute()
  {
    _isMuted = !_isMuted;
  }

  public bool IsMuted()
  {
    return _isMuted;
  }
}