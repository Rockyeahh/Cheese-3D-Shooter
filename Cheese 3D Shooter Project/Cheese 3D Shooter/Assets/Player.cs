using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // Throw is whether it is pushed in one direction or the other. So -horizontal or just horizontal.
        print(horizontalThrow);
	}
}
