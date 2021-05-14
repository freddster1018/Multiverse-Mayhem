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
  private float spawnInterval;

  [SerializeField]
  private float speed;

  private float spawnTimer;
  private bool isGameOver = false;

  private void Start()
  {
    spawnTimer = spawnInterval;

    Character.OnGameOver += HandleGameOver;
  }

  private void OnDestroy()
  {
    Character.OnGameOver -= HandleGameOver;
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
    GameObject obstacle = Instantiate(obstaclePrefabTop, spawnLocationTop.transform.position, spawnLocationTop.transform.rotation);

    obstacle.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * Time.fixedDeltaTime);
  }

  private void HandleGameOver()
  {
    isGameOver = true;
  }
}