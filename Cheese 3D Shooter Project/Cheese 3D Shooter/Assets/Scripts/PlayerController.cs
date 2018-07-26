using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    // TODO: Work-out why sometimes slow on the first play of the scene/level 1.

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 20f; // Does the same as public but he likes using it throughout the 2.0 course. Set to 4f as a default.
                                                              // I don't know what ms^-1 means but I think it's a shorthand for the calculaion that we have done.
    [Tooltip("In m")] [SerializeField] float xRange = 5f; // Ben's code
    [Tooltip("in m")] [SerializeField] float yRange = 4.5f; // Ben's code. // It should be between 0f and 9f. Maybe it should be a slider.
    [SerializeField] GameObject[] guns; // It contains the two or more guns on the player ship.

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f; // Ben's code. The number is world units and this game they are meters.
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f; // Ben's code. Maybe it's to do with the ships nose pointing in directions.
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    void Update ()
    {
        if (isControlEnabled == true)
        {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
        }

    }

    void OnPlayerDeath() // Called by a string reference.
    {
        isControlEnabled = false; // It doesn't stop the camera movement, that wuld be stopped by setting controlSpeed to 0f.
        SetGunsActive(false);
    }

    private void ProcessRotation()
    {
        //float pitch = -17.116f;
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow; // Fuck knows.
        // Ben's code. No idea what it is for. // In Ben's video, it changes the x rotation when the ship moves up and down.


        float yaw = transform.localPosition.x * positionYawFactor;
        
        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // Throw is whether it is pushed in one direction or the other. So -horizontal or just horizontal.
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;               // xOffset is controls(xThrow) * speed * Time.deltaTime or frame time. If the framrate is slow then the ship is slow.
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        // float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // Ben's code
        float rawYPos = transform.localPosition.y + yOffset;
        // float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange); // Ben's code

        //transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); // Ben's code
        transform.localPosition = new Vector3(Mathf.Clamp(rawXPos, -xRange, xRange), transform.localPosition.y, transform.localPosition.z); // Moves the ship in x.
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(rawYPos, -yRange, yRange), transform.localPosition.z); // Moves the ship in y.
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive; // Why isActive? Why does this work? What does false and true have to do with it? Shouldn't they be here? Why does true fail in it's place.
        }
    }
}
