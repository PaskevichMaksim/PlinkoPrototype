using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
  public static ObjectPool Instance { get; private set; }

  private readonly Queue<GameObject> _objectPool = new Queue<GameObject>();

  [SerializeField]
  private GameObject _objectPrefab;
  [SerializeField]
  private int _initialPoolSize = 15;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    } else
    {
      Destroy(gameObject);
    }
  }

  private void Start()
  {
    for (int i = 0; i < _initialPoolSize; i++)
    {
      GameObject obj = Instantiate(_objectPrefab);
      obj.SetActive(false);
      _objectPool.Enqueue(obj);
    }
  }

  public GameObject GetObject()
  {
    if (_objectPool.Count > 0)
    {
      GameObject obj = _objectPool.Dequeue();
      obj.SetActive(true);
      InitializeObject(obj);
      return obj;
    } else
    {
      GameObject obj = Instantiate(_objectPrefab);
      InitializeObject(obj);
      return obj;
    }
  }

  public void ReturnObject(GameObject obj)
  {
    obj.SetActive(false);
    _objectPool.Enqueue(obj);
  }

  private void InitializeObject(GameObject obj)
  {
    Ball ball = obj.GetComponent<Ball>();
    if (ball != null)
    {
      ball.Initialize();
    }
  }
}