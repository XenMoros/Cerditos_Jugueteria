using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BallRotator : MonoBehaviour
{
    public SphereCollider sphereCollider;

    Vector3 sphereCenter;
    // Update is called once per frame
    void Update()
    {
        sphereCenter = sphereCollider.bounds.center;
        transform.RotateAround(sphereCenter, Vector3.forward, 360f * Time.deltaTime);
    }
}
