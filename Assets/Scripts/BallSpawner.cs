using UnityEngine;

public class BallSpawner : MonoBehaviour
{
  [SerializeField]
  private float _spawnInterval = 2f;
  [SerializeField]
  private float _initialForce = 2f;

  private float _timer;

  private void Update()
  {
    _timer += Time.deltaTime;

    if (!Input.GetKeyDown(KeyCode.Space) && !(_timer >= _spawnInterval))
    {
      return;
    }

    SpawnBall();
    _timer = 0f;
  }

  private void SpawnBall()
  {
    const float OFFSET = 2f;
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