using UnityEngine;

public class Basket : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.TryGetComponent(out Ball ball))
    {
      ObjectPool.Instance.ReturnObject(ball.gameObject);
    }
  }
}