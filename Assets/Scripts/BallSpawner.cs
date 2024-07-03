using UnityEngine;

public class BallSpawner : MonoBehaviour
{
  [SerializeField]
  private Ball _ballPrefab;
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
    Vector3 spawnPosition = new Vector3(0, PinPlacer.Instance.GetTopPosition(), 0);

    GameObject ball = Instantiate(_ballPrefab.gameObject, spawnPosition, Quaternion.identity);
        
    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
    Vector2 force = new Vector2(Random.Range(-_initialForce, _initialForce), -_initialForce);
    rb.AddForce(force, ForceMode2D.Impulse);
  }
}