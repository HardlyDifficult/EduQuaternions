using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{

  [SerializeField]
  float sleepTime = .2f;

  Text text;

  protected void Awake()
  {
    text = GetComponent<Text>();
  }

  protected void Start()
  {
    StartCoroutine(PlayFlash());
  }

  IEnumerator PlayFlash()
  {
    for (int i = 0; i < 3; i++)
    {
      yield return new WaitForSeconds(sleepTime);
      text.enabled = !text.enabled;
    }
    text.enabled = true;
  }
}
