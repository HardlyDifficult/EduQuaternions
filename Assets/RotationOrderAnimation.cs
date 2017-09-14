using System;
using System.Collections;
using UnityEngine;

public class RotationOrderAnimation : AnimationMonoBehaviour
{
  [SerializeField]
  bool isChild;

  protected void OnEnable()
  {
    StartCoroutine(PlayAnimation());
  }

  IEnumerator PlayAnimation()
  {
    while (true)
    {
      currentRotation = transform.localRotation.eulerAngles;

      if (isChild)
      {
        yield return LerpTo(new Vector3(90, 0, 0), 1f);
      } else
      {
        yield return LerpTo(new Vector3(0, 0, 90), 1f);
      }
    }
  }
}
