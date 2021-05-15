using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
  [SerializeField]
  private Rigidbody2D rb = null;

  [SerializeField]
  private Animator animator = null;

  [SerializeField]
  private float jumpHeight;

  private bool isDodging = false;

  public static event Action OnGameOver;

  private void Update()
  {
    if (isDodging) { return; }

    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      Jump();
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      StartCoroutine(Slide());
    }
  }

  private void Jump()
  {
    isDodging = true;

    rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime);

    animator.SetTrigger("Jump");
  }

  private IEnumerator Slide()
  {
    isDodging = true;

    animator.SetTrigger("Slide");

    yield return new WaitForSeconds(1);

    animator.SetTrigger("Run");

    isDodging = false;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag.Equals("Obstacle"))
    {
      Destroy(collision.gameObject);
      OnGameOver?.Invoke();
    }
    else if (collision.gameObject.tag.Equals("Floor"))
    {
      isDodging = false;

      animator.SetTrigger("Run");
    }
  }
}
