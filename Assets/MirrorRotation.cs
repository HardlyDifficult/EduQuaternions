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
       
        transform.localRotation = parent.transform.localRotation * (child == null ? Quaternion.identity : child.transform.localRotation);
        break;
      case MirrorType.ChildParent_Wrong:
        transform.localRotation = (child == null ? Quaternion.identity : child.transform.localRotation) * parent.transform.rotation;
        break;
      case MirrorType.ParentInverse:
        transform.localRotation = Quaternion.Inverse(parent.transform.rotation);
        break;
      default:
        break;
    }
  }
}
