using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float speed = 20f; // Does the same as public but he likes using it throughout the 2.0 course. Set to 4f as a default.
                                                              // I don't know what ms^-1 means but I think it's a shorthand for the calculaion that we have done.
    //[Tooltip("In m")] [SerializeField] float xRange = 5f; // Ben's code
    //[Tooltip("in m")] [SerializeField] float yRange = 3f // Ben's code.


	void Start () {

	}
	
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // Throw is whether it is pushed in one direction or the other. So -horizontal or just horizontal.
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;               // xOffset is controls(xThrow) * speed * Time.deltaTime.
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        // float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // Ben's code
        float rawYPos = transform.localPosition.y + yOffset;
        // float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange); // Ben's code

        //transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); // Ben's code
        transform.localPosition = new Vector3 (Mathf.Clamp(rawXPos, -5f, 5f), transform.localPosition.y, transform.localPosition.z); // Moves the ship in x.
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(rawYPos, -5f, 0f), transform.localPosition.z); // Moves the ship in y.
    }

}
