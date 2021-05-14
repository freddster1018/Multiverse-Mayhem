using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
  [SerializeField]
  private List<TMP_Text> hsTexts = new List<TMP_Text>();

  [SerializeField]
  private CanvasGroup menuCanvasGroup = null;

  [SerializeField]
  private CanvasGroup hsCanvasGroup = null;

  public void StartGame()
  {
    SceneManager.LoadScene("Game");
  }

  public void Quit()
  {
    Application.Quit();
  }

  public void OpenCloseHighScores(bool shouldOpen)
  {
    menuCanvasGroup.alpha = shouldOpen ? 0 : 1;
    menuCanvasGroup.interactable = !shouldOpen;
    menuCanvasGroup.blocksRaycasts = !shouldOpen;

    hsCanvasGroup.alpha = shouldOpen ? 1 : 0;
    hsCanvasGroup.interactable = shouldOpen;
    hsCanvasGroup.blocksRaycasts = shouldOpen;

    if (!shouldOpen) { return; }

    SetHighScoreTexts();
  }

  private void SetHighScoreTexts()
  {
    hsTexts[0].text = $"1. {PlayerPrefs.GetFloat("hs1").ToString("F2")}";
    hsTexts[1].text = $"2. {PlayerPrefs.GetFloat("hs2").ToString("F2")}";
    hsTexts[2].text = $"3. {PlayerPrefs.GetFloat("hs3").ToString("F2")}";
  }

  public void ClearHighScores()
  {
    PlayerPrefs.SetFloat("hs1", 0.0f);
    PlayerPrefs.SetFloat("hs2", 0.0f);
    PlayerPrefs.SetFloat("hs3", 0.0f);

    SetHighScoreTexts();
  }
}
