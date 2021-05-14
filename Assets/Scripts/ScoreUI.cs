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

    float hs1 = PlayerPrefs.GetFloat("hs1");
    float hs2 = PlayerPrefs.GetFloat("hs2");
    float hs3 = PlayerPrefs.GetFloat("hs3");

    List<float> sort = new List<float>(new float[] { score, hs1, hs2, hs3 });
    sort.Sort();

    PlayerPrefs.SetFloat("hs1", sort[3]);
    PlayerPrefs.SetFloat("hs2", sort[2]);
    PlayerPrefs.SetFloat("hs3", sort[1]);
  }
}
