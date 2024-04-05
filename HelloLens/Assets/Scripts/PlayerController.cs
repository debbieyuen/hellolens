using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction movement;
    [SerializeField] float xRange = 10f;
    [SerializeField] float zRange = 10f;
    [SerializeField] float controlSpeed = 30f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float zThrow;

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessTranslation();
    }

    private void ProcessRotation()
    {
        // Calculate the player's pitch, yaw, and roll
        float pitchDueToPosition = transform.localPosition.z * positionPitchFactor;
        float pitchDueToControlThrow = zThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
    }

    private void ProcessTranslation()
    {
        // Read the player input
        xThrow = movement.ReadValue<Vector2>().x;
        zThrow = movement.ReadValue<Vector2>().y;

        // Calculate the player's position
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float zOffset = zThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawZPos = transform.localPosition.z + zOffset;

        // Limit the player's position
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedZPos = Mathf.Clamp(rawZPos, -zRange, zRange);

        // Update the player's position
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, clampedZPos);

    }

}
