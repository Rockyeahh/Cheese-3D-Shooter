using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // Will need a if this doesn't exist then don't destroy on load, otherwise you don't need to keep this from destrouction as it'll be replaced.
    }

    void Start () {
        
    }
	
	void Update () {
		
	}
}
