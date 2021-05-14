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
  private float spawnInterval = 5.0f;

  [SerializeField]
  private float speed = 1.0f;

  private float spawnTimer;

  private void Start()
  {
    spawnTimer = spawnInterval;
  }

  private void Update()
  {
    spawnTimer -= Time.deltaTime;

    if (spawnTimer > 0.0f) { return; }

    Spawn();

    spawnTimer = spawnInterval;
  }

  private void Spawn()
  {
    GameObject obstacle = Instantiate(obstaclePrefabTop, spawnLocationTop.transform.position, spawnLocationTop.transform.rotation);

    obstacle.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * Time.deltaTime);
  }
}
