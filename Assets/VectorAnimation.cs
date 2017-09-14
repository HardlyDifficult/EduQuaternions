using System;
using System.Collections;
using UnityEngine;

public class VectorAnimation : AnimationMonoBehaviour
{
  protected void OnEnable()
  {
    StartCoroutine(PlayAnimation());
  }

  IEnumerator PlayAnimation()
  {
    while (true)
    {
      currentRotation = transform.localRotation.eulerAngles;

      yield return LerpTo(new Vector3(0, 0, 90), .1f);
      yield return LerpTo(new Vector3(90, 0, 90), .1f);
      yield return LerpTo(new Vector3(90, 0, 0), .1f);
      yield return LerpTo(new Vector3(0, 0, 0), .1f);
    }
  }
}
