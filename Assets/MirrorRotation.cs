using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotation : MonoBehaviour
{
  public enum MirrorType
  {
    ParentChild, ChildParent_Wrong, ParentInverse
  }

  [SerializeField]
  GameObject parent, child;

  [SerializeField]
  MirrorType mirrorType;

  protected void Update()
  {
    switch (mirrorType)
    {
      case MirrorType.ParentChild:
        transform.rotation = parent.transform.rotation * child.transform.localRotation;
        break;
      case MirrorType.ChildParent_Wrong:
        transform.rotation = child.transform.localRotation * parent.transform.rotation;
        break;
      case MirrorType.ParentInverse:
        transform.rotation = Quaternion.Inverse(parent.transform.rotation);
        break;
      default:
        break;
    }
  }
}
