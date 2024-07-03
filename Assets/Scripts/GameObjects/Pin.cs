using DG.Tweening;
using UnityEngine;

public class Pin : MonoBehaviour, IAnimatable
{
  [SerializeField]
  private float _animationScaleFactor = 1.2f;
  [SerializeField]
  private float _animationDuration = 0.2f;

  private bool _isAnimating;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (!collision.gameObject.TryGetComponent(out Ball _) || _isAnimating)
    {
      return;
    }

    Animate();
    SoundController.Instance.PlaySound(Enums.SoundType.Pin);
  }

  private void Animate()
  {
    _isAnimating = true;
    transform.DOScale(transform.localScale * _animationScaleFactor, _animationDuration).SetLoops(2, LoopType.Yoyo).OnComplete(() => _isAnimating = false);
  }
}