using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextRotation : RotationMonoBehaviour
{
  Text text;

  [SerializeField]
  bool isAxisAngle;
  

  protected void Start()
  {
    text = GetComponent<Text>();
  }

  public override void OnRotationUpdate(
    Vector3 euler,
    Vector3 axis,
    float angle,
    bool isAxisAngle)
  {
    if(text == null)
    {
      return;
    }
    if (this.isAxisAngle == false)
    {
      text.text = string.Format("X: {0} \nY: {1}\nZ: {2}",
        euler.x.ToString("N0"), euler.y.ToString("N0"), euler.z.ToString("N0"));
    }
    else
    {
      text.text = string.Format("({0}, {1}, {2})\n{3}°",
        axis.x.ToString("N1"), axis.y.ToString("N1"), axis.z.ToString("N1"), 
        angle.ToString("N0"));
    }
  }
}
