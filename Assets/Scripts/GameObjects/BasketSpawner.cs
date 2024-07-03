using UnityEngine;

public class BasketSpawner : MonoBehaviour
{
  private const float BASKET_Y_OFFSET = 1.5f;
  private const float BASKET_SCALE_MULTIPLIER = 1.5f;
  
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
    float pinScale = PinPlacer.Instance.GetPinScale();
    float spacingX = pinScale * 2f;
    int basketCount = PinPlacer.Instance.Rows + 1;

    float startY = PinPlacer.Instance.GetBottomPosition() - pinScale * BASKET_Y_OFFSET;

    int[] points = new int[basketCount];
    int basePoints = 10;

    for (int i = 0; i <= basketCount / 2; i++)
    {
      points[basketCount / 2 + i] = basePoints;
      points[basketCount / 2 - i] = basePoints;
      basePoints *= 2;
    }

    for (int i = 0; i < basketCount; i++)
    {
      float xPosition = (i - basketCount / 2f + 0.5f) * spacingX;
      Vector3 position = new Vector3(xPosition, startY, 0);
      GameObject basket = Instantiate(_basketPrefab, position, Quaternion.identity, transform);
      basket.transform.localScale = new Vector3(pinScale * BASKET_SCALE_MULTIPLIER, pinScale * BASKET_SCALE_MULTIPLIER, 1.0f);

      Basket basketComponent = basket.GetComponent<Basket>();
      basketComponent.Points = points[i];
      basketComponent.ColorLerpFactor = Mathf.Abs(i - basketCount / 2f) / (basketCount / 2f);
      basketComponent.UpdateBasket();
    }
  }
}