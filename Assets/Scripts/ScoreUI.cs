using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
  [SerializeField]
  private TMP_Text scoreText = null;

  private float score = 0.0f;
  private bool isGameOver = false;

  private void Start()
  {
    Character.OnGameOver += HandleGameOver;
  }

  private void OnDestroy()
  {
    Character.OnGameOver -= HandleGameOver;
  }

  private void Update()
  {
    if (isGameOver) { return; }

    score += Time.deltaTime;

    scoreText.text = $"Score: {score.ToString("F2")}";
  }

  private void HandleGameOver()
  {
    isGameOver = true;
  }
}
