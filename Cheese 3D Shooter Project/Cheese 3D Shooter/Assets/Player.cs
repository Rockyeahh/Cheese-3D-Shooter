using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f; // does the same as public but he likes using it throughout the 2.0 course. 
                                                             // He sets it to 4 rather than 1f inthe inspector like I did.
                                                             // I don't know what ms^-1 means but I think it's a shorthand for the calculaion we have done.

	void Start () {

	}
	
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // Throw is whether it is pushed in one direction or the other. So -horizontal or just horizontal.
        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        print(xOffsetThisFrame);
	}

}
