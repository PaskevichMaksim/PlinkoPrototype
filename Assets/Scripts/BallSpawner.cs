using UnityEngine;

public class BallSpawner : MonoBehaviour
{
  public static BallSpawner Instance { get; private set; }
  
  [SerializeField]
  private float _initialForce = 2f;
  
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
  
  public void SpawnBall()
  {
    const float OFFSET = .5f;
    Vector3 spawnPosition = new Vector3(0, PinPlacer.Instance.GetTopPosition() + OFFSET, 0);

    GameObject ball = ObjectPool.Instance.GetObject();
    ball.transform.position = spawnPosition;
    ball.transform.SetParent(transform);

    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
    rb.velocity = Vector2.zero;
    rb.angularVelocity = 0;

    Vector2 force = new Vector2(Random.Range(-_initialForce, _initialForce), -_initialForce);
    rb.AddForce(force, ForceMode2D.Impulse);
  }
}