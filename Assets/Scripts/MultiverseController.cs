using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiverseController : MonoBehaviour
{
  [SerializeField]
  private Animator explosionAnimator = null;

  [SerializeField]
  private Image background = null;

  [SerializeField]
  private float travelInterval;

  private bool isGameOver = false;
  private float timer;

  private void Start()
  {
    Character.OnGameOver += HandleGameOver;

    timer = travelInterval;
  }

  private void OnDestroy()
  {
    Character.OnGameOver -= HandleGameOver;
  }

  private void Update()
  {
    if (isGameOver) { return; }

    timer -= Time.deltaTime;

    if (timer > 0) { return; }

    timer = travelInterval;

    explosionAnimator.SetTrigger("Explode");
  }

  private void HandleGameOver()
  {
    isGameOver = true;
  }
}
