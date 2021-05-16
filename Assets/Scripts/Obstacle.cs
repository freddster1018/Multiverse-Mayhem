using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  [SerializeField]
  private AudioSource batSFX = null;

  [SerializeField]
  private float batSFXInterval;

  private float batSFXTimer;

  private void Start()
  {
    batSFXTimer = batSFXInterval;
  }

  private void Update()
  {
    batSFXTimer -= Time.deltaTime;

    if (batSFXTimer > 0.0f) { return; }

    batSFXTimer = batSFXInterval;
    batSFX.Play();
  }
}
