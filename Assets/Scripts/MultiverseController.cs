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
  private List<Sprite> bgSprites = new List<Sprite>();

  [SerializeField]
  private float travelInterval;

  [SerializeField]
  private AudioSource explosionSFX = null;

  private bool isGameOver = false;
  private float timer;
  private int currentIndex = 0;

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
    explosionSFX.Play();

    explosionAnimator.SetTrigger("Explode");

    bool foundBg = false;
    int index = 0;

    while (!foundBg)
    {
      index = Random.Range(0, bgSprites.Count);
      foundBg = index != currentIndex;
    }

    currentIndex = index;
    background.sprite = bgSprites[index];
  }
}
