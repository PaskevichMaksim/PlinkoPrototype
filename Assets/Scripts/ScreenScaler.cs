using UnityEngine;

public class ScreenScaler : MonoBehaviour
{
  public static ScreenScaler Instance { get; private set; }

  public float ScreenHeight { get; private set; }
  public float ScreenWidth { get; private set; }

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      CalculateScreenSize();
    } else
    {
      Destroy(gameObject);
    }
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