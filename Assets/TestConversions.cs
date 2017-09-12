using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConversions : MonoBehaviour
{
  [SerializeField]
  GameObject model;

  protected void Update()
  {
Vector3 axis;
float angle;
transform.rotation.ToAngleAxis(out angle, out axis);
angle *= Mathf.Deg2Rad;

Quaternion rotation = new Quaternion(
  axis.x * Mathf.Sin(angle / 2),
  axis.y * Mathf.Sin(angle / 2),
  axis.z * Mathf.Sin(angle / 2),
  Mathf.Cos(angle / 2));




    float delta = Quaternion.Angle(transform.rotation, rotation);
    if (model != null)
    {
      model.transform.rotation = rotation;
    }
  }
}
