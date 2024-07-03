using UnityEngine;

public class BallSpawner : Singleton<BallSpawner>
{
  [SerializeField]
  private float _initialForce = 1f;
  
  public void SpawnBall()
  {
    Vector3 spawnPosition = new Vector3(0, PinPlacer.Instance.GetTopPosition(), 0);

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