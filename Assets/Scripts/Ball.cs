using UnityEngine;

public class Ball : MonoBehaviour
{
  private void OnEnable()
  {
    PinPlacer.Instance.OnPinsPlaced += SetScale;
  }

  private void OnDisable()
  {
    PinPlacer.Instance.OnPinsPlaced -= SetScale;
  }

  private void SetScale()
  {
    float ballScale = PinPlacer.Instance.GetPinScale() * 2f;
    transform.localScale = new Vector3(ballScale, ballScale, 1.0f);
  }
}