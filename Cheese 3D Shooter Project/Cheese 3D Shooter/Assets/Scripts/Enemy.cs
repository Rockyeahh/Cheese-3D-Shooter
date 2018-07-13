using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;

	void Start ()
    {
        AddBoxCollider(); // Maybe call this in Awake instead.
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); // original object, world space position, Don't rotate.
        fx.transform.parent = parent; // Sets the parent transform to the fx variable that contains the instance. Thus putting it on parent, which is the Spawned At Run Time GameObject.
        Destroy(gameObject); // Does it respawn after a Player death and Player respawn/reset?
    }
    
}
