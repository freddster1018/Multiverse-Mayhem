using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
  [SerializeField]
  private GameObject obstaclePrefabTop = null;

  [SerializeField]
  private GameObject spawnLocationTop = null;

  [SerializeField]
  private GameObject spawnLocationBottom = null;

  [SerializeField]
  private float spawnInterval;

  [SerializeField]
  private float speed;

  private float spawnTimer;
  private bool isGameOver = false;

  private void Start()
  {
    spawnTimer = spawnInterval;

    Character.OnGameOver += HandleGameOver;
    MultiverseController.OnTravel += HandleTravel;
  }

  private void OnDestroy()
  {
    Character.OnGameOver -= HandleGameOver;
    MultiverseController.OnTravel += HandleTravel;
  }

  private void Update()
  {
    if (isGameOver) { return; }

    spawnTimer -= Time.deltaTime;

    if (spawnTimer > 0.0f) { return; }

    Spawn();

    spawnTimer = spawnInterval;
  }

  private void Spawn()
  {
    float random = Random.Range(0, 2);

    GameObject spawnLocation = random < 0.5f ? spawnLocationTop : spawnLocationBottom;

    GameObject obstacle = Instantiate(obstaclePrefabTop, spawnLocation.transform.position, spawnLocation.transform.rotation);

    obstacle.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * Time.fixedDeltaTime);
  }

  private void HandleGameOver()
  {
    isGameOver = true;
  }

  private void HandleTravel()
  {
    spawnInterval -= 0.2f;

    spawnInterval = Mathf.Clamp(spawnInterval, 2.0f, Mathf.Infinity);
  }
}
