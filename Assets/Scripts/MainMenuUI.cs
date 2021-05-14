using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
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

  }
}
