using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
  Vector3 from, to;
  bool isGoingTo;

  [SerializeField]
  float speed = 10;

  protected void Start()
  {
    from = transform.position + new Vector3(-3, 0, 0);
    to = transform.position + new Vector3(3, 0, 0);

    StartCoroutine(Move());
  }

  private IEnumerator Move()
  {
    yield return null;

    while (true)
    {
      for (int i = 0; i < 100; i++)
      {
        transform.position = Vector3.Lerp(from, to, (float)i / 100);
        yield return null;
      }
      yield return new WaitForSeconds(.5f);
      for (int i = 0; i < 100; i++)
      {
        transform.position = Vector3.Lerp(to, from, (float)i / 100);
        yield return null;
      }
      yield return new WaitForSeconds(.5f);

    }
  }
}
