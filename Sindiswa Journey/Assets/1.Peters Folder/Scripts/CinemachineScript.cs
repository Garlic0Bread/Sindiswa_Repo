using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineScript : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;

    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private float bottomClamp = -40f;
    [SerializeField]
    private float topClamp = 70f;
    [SerializeField]
    private float rotationDamping = 0.1f; // New parameter for smoothing

    private float cinemachineTargetPitch;
    private float cinemachineTargetYaw;

    private void LateUpdate()
    {
        CameraLogic();
    }

    private void CameraLogic()
    {
        float mouseX = GetMouseInput("Mouse X");
        float mouseY = GetMouseInput("Mouse Y");

        // Update target rotations with interpolation
        cinemachineTargetPitch = UpdateRotation(cinemachineTargetPitch, mouseY, bottomClamp, topClamp, true);
        cinemachineTargetYaw = UpdateRotation(cinemachineTargetYaw, mouseX, float.MinValue, float.MaxValue, false);

        // Apply rotations with smoothing
        ApplyRotations(cinemachineTargetPitch, cinemachineTargetYaw);
    }

    private void ApplyRotations(float pitch, float yaw)
    {
        // Smooth the rotation using LerpAngle for yaw and pitch
        float smoothPitch = Mathf.LerpAngle(followTarget.eulerAngles.x, pitch, rotationDamping);
        float smoothYaw = Mathf.LerpAngle(followTarget.eulerAngles.y, yaw, rotationDamping);

        followTarget.rotation = Quaternion.Euler(smoothPitch, smoothYaw, followTarget.eulerAngles.z);
    }

    private float UpdateRotation(float currentRotation, float input, float min, float max, bool isXAxis)
    {
        currentRotation += isXAxis ? -input : input;
        return Mathf.Clamp(currentRotation, min, max);
    }

    private float GetMouseInput(string axis)
    {
        return Input.GetAxis(axis) * rotationSpeed * Time.deltaTime;
    }

}
