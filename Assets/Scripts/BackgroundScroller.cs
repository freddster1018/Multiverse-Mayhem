using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
  [SerializeField]
  private float speed;

  [SerializeField]
  private Image image;

  private void Update()
  {
    Vector2 offset = new Vector2(Time.time * speed, 0);

    image.materialForRendering.mainTextureOffset = offset;
  }
}
