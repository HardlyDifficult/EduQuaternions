using System;
using System.Collections;
using UnityEngine;

public class AnimationMonoBehaviour : MonoBehaviour
{
  RotationMonoBehaviour[] iCareList;

  bool hasUpdated;

  protected Vector3 currentRotation;

  [SerializeField]
  protected GameObject message;

  protected virtual void Awake()
  {
    iCareList = Resources.FindObjectsOfTypeAll<RotationMonoBehaviour>();
  }

  protected void OnDisable()
  {
    StopAllCoroutines();
  }

  protected void Start()
  {
    BroadcastUpdate(transform.localRotation.eulerAngles, false);
  }

  protected void Update()
  {
    hasUpdated = false;
  }

  protected void LateUpdate()
  {
    if (hasUpdated == false)
    {
      //BroadcastUpdate(transform.rotation.eulerAngles);
    }
    hasUpdated = false;
  }

  protected void BroadcastUpdate(
    Vector3 euler,
    bool isAxisAngle)
  {
    hasUpdated = true;
    for (int i = 0; i < iCareList.Length; i++)
    {
      RotationMonoBehaviour iCare = iCareList[i];
      float angle;
      Vector3 axis;
      transform.localRotation.ToAngleAxis(out angle, out axis);
      iCare.OnRotationUpdate(euler, axis, angle, isAxisAngle);
    }
  }

  protected void BroadcastUpdate(
    Vector3 axis,
    float angle,
    bool isAxisAngle)
  {
    hasUpdated = true;
    for (int i = 0; i < iCareList.Length; i++)
    {
      RotationMonoBehaviour iCare = iCareList[i];
      Vector3 euler = Quaternion.AngleAxis(angle, axis).eulerAngles;
      iCare.OnRotationUpdate(euler, axis, angle, isAxisAngle);
    }
  }

  protected IEnumerator LerpTo(
    Vector3 euler,
    float timeTillComplete)
  {
    timeTillComplete *= 5;
    float progress = 0;
    while (progress < timeTillComplete)
    {
      float percentComplete = progress / timeTillComplete;
      Vector3 targetRotation = Vector3.Lerp(currentRotation, euler, percentComplete);
      SetRotation(targetRotation, false);
      yield return null;
      progress += Time.deltaTime;
    }
    SetRotation(euler, false);
    currentRotation = euler;
  }

  protected IEnumerator LerpTo(
    Vector3 axis,
    float angle,
    float timeTillComplete)
  {
    bool goBackwards = false;
    if (angle > 180)
    {
      goBackwards = true;
    }
    Quaternion initialRotation = Quaternion.AngleAxis(0, axis);

    while (Mathf.Abs(Quaternion.Dot(initialRotation, transform.localRotation)) < .9999)
    {
      transform.localRotation = Quaternion.RotateTowards(transform.localRotation, initialRotation, 500f * Time.deltaTime);
      yield return null;
    }
    transform.localRotation = initialRotation;

    yield return new WaitForSeconds(.25f);

    timeTillComplete *= 5;
    float progress = 0;
    Vector3 targetRotation = Vector3.zero;
    while (progress < timeTillComplete)
    {
      float percentComplete = progress / timeTillComplete;
      float currentAngle;
      if (goBackwards)
      {
        float range = 360 - angle;
        float offset = range * percentComplete;
        currentAngle = 360 - offset;
      }
      else
      {
        currentAngle = angle * percentComplete;
      }
      targetRotation = Quaternion.AngleAxis(currentAngle, axis).eulerAngles;
      SetRotation(axis, currentAngle, true);
      yield return null;
      progress += Time.deltaTime;
    }
    SetRotation(axis, angle, true);
    currentRotation = targetRotation;
  }

  void SetRotation(
    Vector3 euler,
    bool isAxisAngle)
  {
    Quaternion rotation = Quaternion.Euler(euler);
    transform.localRotation = rotation;
    BroadcastUpdate(euler, isAxisAngle);
  }

  void SetRotation(
    Vector3 axis,
    float angle,
    bool isAxisAngle)
  {
    if (message != null)
    {
      message.SetActive(true);
    }
    Quaternion rotation = Quaternion.AngleAxis(angle, axis);
    transform.localRotation = rotation;
    BroadcastUpdate(axis, angle, isAxisAngle);
  }
}
