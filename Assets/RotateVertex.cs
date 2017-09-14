using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateVertex : MonoBehaviour
{
  [SerializeField]
  GameObject model;

  Vector3 positionOffset;

  protected void Start()
  {
    positionOffset = transform.position - model.transform.position;
  }

  protected void Update()
  {
    Debug.DrawLine(transform.position, model.transform.position, Color.black);


    transform.position = model.transform.position + model.transform.rotation * positionOffset;
  }
}
