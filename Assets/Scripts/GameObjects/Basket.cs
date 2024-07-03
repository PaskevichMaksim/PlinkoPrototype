using DG.Tweening;
using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour, IAnimatable
{
  [SerializeField]
  private SpriteRenderer _spriteRenderer;
  [SerializeField]
  private TextMeshPro _pointsText;
  [SerializeField]
  private float _animationScaleFactor = 1.2f;
  [SerializeField]
  private float _animationDuration = 0.1f;

  public int Points { get; set; }
  public float ColorLerpFactor { get; set; }

  private bool _isAnimating;

  public void UpdateBasket()
  {
    _spriteRenderer.color = GetColorBasedOnLerpFactor();
    _pointsText.text = Points.ToString();
  }

  private Color GetColorBasedOnLerpFactor()
  {
    return Color.Lerp(Color.green, Color.red, ColorLerpFactor);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.TryGetComponent(out Ball ball))
    {
      ObjectPool.Instance.ReturnObject(ball.gameObject);
      SoundController.Instance.PlaySound(Enums.SoundType.Basket);
      ScoreManager.Instance.AddPoints(Points);
    }

    if (!_isAnimating)
    {
      Animate();
    }
  }

  private void Animate()
  {
    _isAnimating = true;
    transform.DOScale(transform.localScale * _animationScaleFactor, _animationDuration).SetLoops(2, LoopType.Yoyo).OnComplete(() => _isAnimating = false);
  }
}