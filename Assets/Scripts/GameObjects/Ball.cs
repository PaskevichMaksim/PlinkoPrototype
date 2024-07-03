using UnityEngine;

public class Ball : MonoBehaviour
{
  private void Awake()
  {
    PinPlacer.Instance.OnPinsPlaced += SetScale;
  }

  private void OnDestroy()
  {
    PinPlacer.Instance.OnPinsPlaced -= SetScale;
  }

  public void Initialize()
  {
    SetScale();
  }

  private void SetScale()
  {
    float ballScale = PinPlacer.Instance.GetPinScale() * 2f;
    transform.localScale = new Vector3(ballScale, ballScale, 1.0f);
  }
}