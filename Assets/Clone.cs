using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour {

  static bool oneToRuleThemAll;

  [SerializeField]
  int count;

	void Start () {
    if(oneToRuleThemAll)
    {
      return;
    }
    oneToRuleThemAll = true;
    for (int i = 0; i < count; i++)
    {
      Instantiate(gameObject);
    }
	}
	
}
