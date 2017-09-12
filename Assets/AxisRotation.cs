using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotation : RotationMonoBehaviour
{
  protected void Start()
  {
    //gameObject.SetActive(false);
  }

  public override void OnRotationUpdate(
    Vector3 euler,
    Vector3 axis,
    float angle,
    bool isAxisAngle)
  {
    if(isAxisAngle)
    {
      gameObject.SetActive(true);
      transform.up = -axis;
    }
  }
}
