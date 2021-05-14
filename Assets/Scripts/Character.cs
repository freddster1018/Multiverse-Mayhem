using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  private bool isDodging = false;

  private void Update()
  {
    if (isDodging) { return; }

    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      Jump();
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      Slide();
    }
  }

  private void Jump()
  {
    isDodging = true;

    Debug.Log("Jumping");

    isDodging = false;
  }

  private void Slide()
  {
    isDodging = true;

    Debug.Log("Sliding");

    isDodging = false;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag.Equals("Obstacle"))
    {
      Debug.Log("Game Over!");
    }
  }
}
