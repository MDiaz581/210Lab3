using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target; //The transform component of our plane.
    public float LerpSpeed; //How quickly to interpolate the camera's position.
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z); //Where the camera is trying to go.

        transform.position = Vector3.Lerp(transform.position, targetPosition + offset, Time.deltaTime * LerpSpeed);
    }
}
