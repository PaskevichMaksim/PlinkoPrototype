using UnityEngine;

public class BasketSpawner : MonoBehaviour
{
  [SerializeField]
  private GameObject _basketPrefab;

  public void Start()
  {
    PinPlacer.Instance.OnPinsPlaced += SpawnBaskets;
  }

  private void OnDestroy()
  {
    PinPlacer.Instance.OnPinsPlaced -= SpawnBaskets;
  }

  private void SpawnBaskets()
  {
    float basketScale = PinPlacer.Instance.GetPinScale();
    float spacingX = basketScale * 2f;
    int basketCount = PinPlacer.Instance.Rows + 1;

    float startY = PinPlacer.Instance.GetBottomPosition() - basketScale;

    for (int i = 0; i < basketCount; i++)
    {
      float xPosition = (i - basketCount / 2f + 0.5f) * spacingX;
      Vector3 position = new Vector3(xPosition, startY, 0);
      GameObject basket = Instantiate(_basketPrefab, position, Quaternion.identity, transform);
      basket.transform.localScale = new Vector3(basketScale, basketScale, 1.0f);
    }
  }
}