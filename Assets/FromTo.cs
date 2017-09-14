using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromTo : MonoBehaviour
{
  protected void Update()
  {
    Vector3 directionToCamera
      = Camera.main.transform.position - transform.position;




    transform.rotation = Quaternion.FromToRotation(
      Vector3.back, directionToCamera);


      //* Quaternion.Euler(0, 0, 180);
  }
}
