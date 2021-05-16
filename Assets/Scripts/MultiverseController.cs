using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MultiverseController : MonoBehaviour
{
  [SerializeField]
  private Animator explosionAnimator = null;

  [SerializeField]
  private Image background = null;

  [SerializeField]
  private List<Sprite> bgSprites = new List<Sprite>();

  [SerializeField]
  private float travelInterval;

  [SerializeField]
  private AudioSource explosionSFX = null;

  private bool isGameOver = false;
  private float timer;
  private int currentIndex = 0;

  public static event Action OnTravel;

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

    Travel();
  }

  private void HandleGameOver()
  {
    isGameOver = true;
  }

  private void Travel()
  {
    OnTravel?.Invoke();

    explosionSFX.Play();

    explosionAnimator.SetTrigger("Explode");

    bool foundBg = false;
    int index = 0;

    while (!foundBg)
    {
      index = UnityEngine.Random.Range(0, bgSprites.Count);
      foundBg = index != currentIndex;
    }

    currentIndex = index;
    background.sprite = bgSprites[index];
  }
}
