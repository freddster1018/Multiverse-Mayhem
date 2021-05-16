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

  [SerializeField]
  private AudioSource jumpSFX = null;

  [SerializeField]
  private AudioSource slideSFX = null;

  [SerializeField]
  private AudioSource hitSFX = null;

  [SerializeField]
  private AudioSource runSFX = null;

  [SerializeField]
  private float runSFXInterval;

  private bool isDodging = false;
  private bool isSliding = false;

  private float runSFXTimer;

  public static event Action OnGameOver;

  private void Start()
  {
    runSFXTimer = runSFXInterval;
  }

  private void Update()
  {
    if (isDodging) { return; }

    runSFXTimer -= Time.deltaTime;
    if (runSFXTimer <= 0.0f)
    {
      runSFXTimer = runSFXInterval;
      runSFX.Play();
    }

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
    jumpSFX.Play();

    isDodging = true;

    rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime);

    animator.SetTrigger("Jump");
  }

  private IEnumerator Slide()
  {
    slideSFX.Play();

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
      isDodging = true;

      hitSFX.Play();

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
