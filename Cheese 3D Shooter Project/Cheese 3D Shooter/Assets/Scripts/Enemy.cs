using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

	void Start () { // Maybe Awake would be better.
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); // original object, world space position, Don't rotate.
        fx.transform.parent = parent; // Sets the parent transform to the fx variable that contains the instance. Thus putting it on parent, which is the Spawned At Run Time GameObject.
        Destroy(gameObject); // Does it respawn after a Player death and Player respawn/reset?
    }
    
}
