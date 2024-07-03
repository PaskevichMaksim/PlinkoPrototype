using System;
using UnityEngine;

public class PinPlacer : MonoBehaviour
{
    public static PinPlacer Instance { get; private set; }
    
    public event Action OnPinsPlaced;

    [SerializeField]
    private Pin _pinPrefab;
    [SerializeField]
    private int _rows = 10;

    private float _pinScale;
    private float _topPosition;
    private float _botPosition;

    public int Rows => _rows;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        CalculatePinScaleAndSpacing();
        PlacePins();
        OnPinsPlaced?.Invoke();
    }

    private void CalculatePinScaleAndSpacing()
    {
        ScreenScaler screenScaler = ScreenScaler.Instance;
        
        _pinScale = screenScaler.ScreenWidth / (_rows + 2) * 0.4f;
        
        float aspectRatio = screenScaler.ScreenHeight / screenScaler.ScreenWidth;
        
        _pinScale *= Mathf.Lerp(1f, 1.5f, (aspectRatio - 1.5f) / 1.5f);
    }

    private void PlacePins()
    {
        ScreenScaler screenScaler = ScreenScaler.Instance;
        float spacingX = _pinScale * 2f;
        float spacingY = _pinScale * 2f;

        float startY = screenScaler.ScreenHeight / 2 - (_rows * spacingY) / 2 - screenScaler.ScreenHeight / 8;

        float pyramidWidth = (_rows + 2) * spacingX;

        if (pyramidWidth > screenScaler.ScreenWidth)
        {
            float scaleAdjust = screenScaler.ScreenWidth / pyramidWidth;
            _pinScale *= scaleAdjust;
            spacingX *= scaleAdjust;
            spacingY *= scaleAdjust;
        }

        for (int row = 0; row < _rows; row++)
        {
            int pinsInRow = row + 3;
            float rowCenter = (pinsInRow - 1) * spacingX / 2;

            for (int col = 0; col < pinsInRow; col++)
            {
                Vector3 position = new Vector3(col * spacingX - rowCenter, startY - row * spacingY, 0);
                GameObject pin = Instantiate(_pinPrefab.gameObject, position, Quaternion.identity, transform);
                pin.transform.localScale = new Vector3(_pinScale, _pinScale, 1.0f);
            }
        }

        _topPosition = startY + spacingY;
        _botPosition = startY - (_rows - 1) * spacingY;
    }

    public float GetPinScale()
    {
        return _pinScale;
    }

    public float GetTopPosition()
    {
        return _topPosition;
    }
    
    public float GetBottomPosition()
    {
        return _botPosition;
    }
}
