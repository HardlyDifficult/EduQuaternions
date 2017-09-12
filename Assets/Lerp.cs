using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
  [SerializeField]
  float speed = .01f;

  [SerializeField]
  bool usePercentComplete;

  Quaternion originalRotation;

  float progress;

  [SerializeField]
  bool useSlerp;

  protected void Start()
  {
    originalRotation = transform.rotation;
  }

  protected void Update()
  {
    if (usePercentComplete)
    {
      progress += speed * Time.deltaTime;
      progress = Mathf.Clamp01(progress);
      if (useSlerp)
      {
        transform.rotation = Quaternion.Slerp(originalRotation, Quaternion.identity, progress);
      }
      else
      {
        transform.rotation = Quaternion.Lerp(originalRotation, Quaternion.identity, progress);
      }
    }
    else
    {
      if(useSlerp)
      {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, speed * Time.deltaTime);
      }
      else
      {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, speed * Time.deltaTime);
      }
    }
  }
}
