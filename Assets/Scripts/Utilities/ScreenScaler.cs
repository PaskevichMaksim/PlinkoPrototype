using UnityEngine;

public class ScreenScaler : Singleton<ScreenScaler>
{
  public float ScreenHeight { get; private set; }
  public float ScreenWidth { get; private set; }

  private void Awake()
  {
    CalculateScreenSize();
  }

  private void CalculateScreenSize()
  {
    if (Camera.main == null)
    {
      return;
    }

    ScreenHeight = Camera.main.orthographicSize * 2f;
    ScreenWidth = ScreenHeight * Screen.width / Screen.height;

  }
}