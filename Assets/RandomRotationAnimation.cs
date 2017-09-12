using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotationAnimation : AnimationMonoBehaviour
{

  [SerializeField]
  bool zOnly;

  protected void OnEnable()
  {
    StartCoroutine(PlayAnimation());
  }

  IEnumerator PlayAnimation()
  {
    while (true)
    {
      currentRotation = transform.rotation.eulerAngles;
      if (zOnly)
      {
        yield return LerpTo(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)), .5f);
      }
      else
      {
        yield return LerpTo(UnityEngine.Random.onUnitSphere * 360, .5f);
      }
    }
  }
}
