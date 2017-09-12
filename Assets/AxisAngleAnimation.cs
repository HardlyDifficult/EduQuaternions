using System;
using System.Collections;
using UnityEngine;

public class AxisAngleAnimation : AnimationMonoBehaviour
{
  protected void OnEnable()
  {
    StartCoroutine(PlayAnimation());
  }

  IEnumerator PlayAnimation()
  {
    while (true)
    {
      currentRotation = new Vector3(90, 180, 0);
      transform.rotation = Quaternion.Euler(currentRotation);
      const float normalPause = .5f;

      float angle;
      Vector3 axis;
      transform.rotation.ToAngleAxis(out angle, out axis);
      BroadcastUpdate(currentRotation, true);

      yield return new WaitForSeconds(normalPause);
      yield return LerpTo(axis, angle, 1f);

      //currentRotation = new Vector3(90, 270, 0);
      //transform.rotation = Quaternion.Euler(currentRotation);
      //const float normalPause = .5f;
      ////yield return new WaitForSeconds(1);
      ////yield return LerpTo(new Vector3(90, 0, 0), .25f);
      ////yield return LerpTo(new Vector3(90, 0, 90), .25f);

      //float angle;
      //Vector3 axis;
      //transform.rotation.ToAngleAxis(out angle, out axis);
      //BroadcastUpdate(currentRotation, true);

      ////yield return new WaitForSeconds(normalPause);
      ////yield return LerpTo(new Vector3(0, 0, 0), .25f);
      //yield return new WaitForSeconds(normalPause);
      //yield return LerpTo(axis, angle, 1f);

      //yield return new WaitForSeconds(.5f);
      //yield return LerpTo(new Vector3(90, -90, 0), .5f);
      //yield return new WaitForSeconds(.25f);
      //yield return LerpTo(new Vector3(90, 15, 0), .5f);
      //yield return LerpTo(new Vector3(90, 0, 0), .1f);
      //yield return new WaitForSeconds(.5f);
      //yield return LerpTo(new Vector3(90, 0, 90), .5f);
      //yield return new WaitForSeconds(.25f);
      //yield return LerpTo(new Vector3(90, 0, -15), .5f);
      //yield return LerpTo(new Vector3(90, 0, 0), .1f);
      //yield return new WaitForSeconds(.5f);
      //yield return LerpTo(new Vector3(90, -45, 0), .5f);
      //yield return LerpTo(new Vector3(90, -45, 45), .5f);

      yield return new WaitForSeconds(3);
    }
  }
}
