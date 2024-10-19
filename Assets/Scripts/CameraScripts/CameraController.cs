using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (GameManager.Instance.CurrentPlayer == null)
            return;

        Vector3 desiredPosition = GameManager.Instance.CurrentPlayer.transform.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}
