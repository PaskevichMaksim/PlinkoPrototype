using UnityEngine;

public class BackgroundSetup : MonoBehaviour
{
  [SerializeField]
  private SpriteRenderer _backgroundSpriteRenderer;

  private void Start()
  {
    AdjustBackgroundSize();
  }

  private void AdjustBackgroundSize()
  {
    if (Camera.main != null)
    {
      float screenHeight = Camera.main.orthographicSize * 2f;
      float screenWidth = screenHeight * Screen.width / Screen.height;

      Vector2 spriteSize = _backgroundSpriteRenderer.sprite.bounds.size;
      transform.localScale = new Vector3(screenWidth / spriteSize.x, screenHeight / spriteSize.y, 1);
      transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
    }

    _backgroundSpriteRenderer.sortingOrder = -10; 
  }
}