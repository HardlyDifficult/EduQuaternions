using System;
using UnityEngine;

public abstract class RotationMonoBehaviour : MonoBehaviour
{
  public abstract void OnRotationUpdate(
    Vector3 euler,
    Vector3 axis,
    float angle,
    bool isAxisAngle);
}

