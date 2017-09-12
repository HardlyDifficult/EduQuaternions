using System;
using System.Collections;
using UnityEngine;

public class GimbalLockAnimation : AnimationMonoBehaviour
{
  protected void OnEnable()
  {
    StartCoroutine(PlayAnimation());
  }

  IEnumerator PlayAnimation()
  {
    while (true)
    {
      currentRotation = transform.rotation.eulerAngles;

      yield return LerpTo(new Vector3(90, 0, 0), .5f);
      if (message != null)
      {
        message.SetActive(true);
      }
      yield return new WaitForSeconds(.5f);
      yield return LerpTo(new Vector3(90, -180, 0), .5f);
      yield return new WaitForSeconds(.25f);
      yield return LerpTo(new Vector3(90, 20, 0), .5f);
      yield return LerpTo(new Vector3(90, 0, 0), .1f);
      yield return new WaitForSeconds(.5f);
      yield return LerpTo(new Vector3(90, 0, 180), .5f);
      yield return new WaitForSeconds(.25f);
      yield return LerpTo(new Vector3(90, 0, -30), .5f);
      yield return LerpTo(new Vector3(90, 0, 0), .1f);
      yield return new WaitForSeconds(.5f);
      yield return LerpTo(new Vector3(90, -90, 0), .5f);
      yield return LerpTo(new Vector3(90, -90, 90), .5f);

      yield return new WaitForSeconds(3);
    }
  }
}
