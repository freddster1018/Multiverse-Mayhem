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
  private new BoxCollider2D collider = null;

  [SerializeField]
  private float jumpHeight;

  [SerializeField]
  private float slideTime;

  private bool isDodging = false;
  private bool isSliding = false;

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
    isSliding = true;

    animator.SetTrigger("Slide");

    collider.size = new Vector2(0.2239996f, 0.154541f);
    collider.offset = new Vector2(-0.02992642f, -0.08432318f);

    yield return new WaitForSeconds(slideTime);

    animator.SetTrigger("Run");

    collider.size = new Vector2(0.1415217f, 0.3016891f);
    collider.offset = new Vector2(-0.009306952f, -0.01074912f);

    isDodging = false;
    isSliding = false;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag.Equals("Obstacle"))
    {
      Destroy(collision.gameObject);
      OnGameOver?.Invoke();
      animator.SetTrigger("Die");
    }
    else if (collision.gameObject.tag.Equals("Floor") && !isSliding)
    {
      isDodging = false;

      animator.SetTrigger("Run");
    }
  }
}
