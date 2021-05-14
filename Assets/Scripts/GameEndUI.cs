using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{
  [SerializeField]
  private CanvasGroup canvasGroup = null;

  private void Start()
  {
    Character.OnGameOver += HandleGameOver;
  }

  private void OnDestroy()
  {
    Character.OnGameOver -= HandleGameOver;
  }

  private void HandleGameOver()
  {
    canvasGroup.alpha = 1;
    canvasGroup.interactable = true;
    canvasGroup.blocksRaycasts = true;
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void Quit()
  {
    SceneManager.LoadScene("Main Menu");
  }
}
