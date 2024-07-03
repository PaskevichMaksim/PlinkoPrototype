using UnityEngine;

public class BoundaryTrigger : MonoBehaviour
{
  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.TryGetComponent(out Ball ball))
    {
      ObjectPool.Instance.ReturnObject(ball.gameObject);
    }
  }
}