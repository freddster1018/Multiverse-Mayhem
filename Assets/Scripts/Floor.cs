using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
  [SerializeField]
  private new BoxCollider2D collider = null;

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
    collider.enabled = false;
  }
}
