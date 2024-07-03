using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
  [SerializeField]
  private SpriteRenderer _spriteRenderer;
  [SerializeField]
  private TextMeshPro _pointsText;

  public int Points { get; set; }
  public float ColorLerpFactor { get; set; }

  private void Start()
  {
    UpdateBasket();
  }

  public void UpdateBasket()
  {
    if (_spriteRenderer != null)
    {
      _spriteRenderer.color = GetColorBasedOnLerpFactor();
    }

    if (_pointsText != null)
    {
      _pointsText.text = Points.ToString();
    }
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
    }
  }
}