using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  [SerializeField]
  private Rigidbody2D rb = null;

  [SerializeField]
  private float jumpHeight;

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

    rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime);
  }

  private void Slide()
  {
    isDodging = true;

    Debug.Log("Sliding");

    isDodging = false;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag.Equals("Obstacle"))
    {
      Debug.Log("Game Over!");
    }
    else if (collision.gameObject.tag.Equals("Floor"))
    {
      isDodging = false;
    }
  }
}
