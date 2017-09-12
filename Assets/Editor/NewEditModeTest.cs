using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewEditModeTest
{

  [Test]
  public void Dot()
  {
    Quaternion a = Random.rotation;
    Quaternion b = Random.rotation;

    float dot = a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;

    float delta = dot - Quaternion.Dot(a, b);
    Assert.IsTrue(Mathf.Abs(delta) < .1);
  }

  [Test]
  public void RotateVector()
  {
    // Inputs
    Quaternion rotation = Random.rotation;
    Vector3 position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));

    // Prep for calculations
    Quaternion positionQuaternion = new Quaternion(position.x, position.y, position.z, 0);
    Quaternion inverseRotation = Quaternion.Inverse(rotation);

    // Calculate new position
    Quaternion newPositionQuaternion = rotation * positionQuaternion * inverseRotation;
    Vector3 newPosition = new Vector3(newPositionQuaternion.x, newPositionQuaternion.y, newPositionQuaternion.z);

    // Confirm
    Vector3 expected = rotation * position;
    float delta = (expected - newPosition).magnitude;
    Assert.IsTrue(delta < .01);
  }


  [Test]
  public void InverseExample()
  {
    Quaternion rotation = Random.rotation;
    Quaternion inverseRotation = Quaternion.Inverse(rotation);
  }


  [Test]
  public void InverseExample2()
  {
    Quaternion rotation = Random.rotation;

    // Split the Quaternion components
    Vector3 vector = new Vector3(
      rotation.x, rotation.y, rotation.z);
    float scalar = rotation.w;

    // Calculate inverse
    vector = -vector;

    // Return results
    Quaternion inverseRotation = new Quaternion(vector.x, vector.y, vector.z, scalar);



    float delta = Quaternion.Angle(inverseRotation, Quaternion.Inverse(rotation));
    Assert.IsTrue(delta < .1);
  }

  [Test]
  public void EulerExample()
  {
    Quaternion randomRotation = Random.rotation;
    Vector3 inEuler = randomRotation.eulerAngles;
    Quaternion inQuaternion = Quaternion.Euler(inEuler);
  }

  [Test]
  public void Testing()
  {
    for (int i = 0; i < 1000; i++)
    {
      // Split the Quaternion components
      Quaternion parentRotation = Random.rotation;
      Vector3 parentVector = new Vector3(
        parentRotation.x, parentRotation.y, parentRotation.z);
      float parentScalar = parentRotation.w;

      Quaternion childRotation = Random.rotation;
      Vector3 childVector = new Vector3(
        childRotation.x, childRotation.y, childRotation.z);
      float childScalar = childRotation.w;

      // Calculate parentRotation * childRotation
      Quaternion targetRotation;
      Vector3 targetVector = parentScalar * childVector
        + childScalar * parentVector
        + Vector3.Cross(parentVector, childVector);
      float targetScalar = parentScalar * childScalar
        - Vector3.Dot(parentVector, childVector);
      targetRotation = new Quaternion(
        targetVector.x, targetVector.y, targetVector.z, targetScalar);


      // Test
      Quaternion expected = parentRotation * childRotation;
      float delta = Quaternion.Angle(targetRotation, expected);
      Assert.IsTrue(delta < .1);
    }
  }


  [Test]
  public void NewEditModeTestSimplePasses()
  {
    for (int i = 0; i < 1000; i++)
    {
      Quaternion a = Random.rotation;
      Quaternion b = Random.rotation;
      float percentComplete = Random.Range(0, 1);
      //Quaternion expectedRotation = Quaternion.Lerp(a, b, percentComplete);



      //float x = (1 - percentComplete) * a.x + percentComplete * b.x;
      //float y = (1 - percentComplete) * a.y + percentComplete * b.y;
      //float z = (1 - percentComplete) * a.z + percentComplete * b.z;
      //float w = (1 - percentComplete) * a.w + percentComplete * b.w;
      //float factor = Mathf.Sqrt(x * x + y * y + z * z + w * w);
      //x /= factor;
      //y /= factor;
      //z /= factor;
      //w /= factor;
      //Quaternion rotation = new Quaternion(x, y, z, w);



      //float delta = Quaternion.Angle(rotation, expectedRotation);
      //Assert.IsTrue(delta < .1);



      // Define terms
      //Quaternion a = transform.rotation;
      //Quaternion b = targetRotation;

      // Split the Quaternion components
      Vector3 aVector = new Vector3(a.x, a.y, a.z);
      float aScalar = a.w;
      Vector3 bVector = new Vector3(b.x, b.y, b.z);
      float bScalar = b.w;

      // Calculate target quaternion values
      Vector3 targetVector = (1 - percentComplete) * aVector + percentComplete * bVector;
      float targetScalar = (1 - percentComplete) * aScalar + percentComplete * bScalar;

      // Normalize results
      float factor = Mathf.Sqrt(targetVector.sqrMagnitude + targetScalar * targetScalar);
      targetVector /= factor;
      targetScalar /= factor;

      // Update the rotation to the lerped value
      Quaternion result = new Quaternion(
        targetVector.x, targetVector.y, targetVector.z, targetScalar);
    }
  }
}
