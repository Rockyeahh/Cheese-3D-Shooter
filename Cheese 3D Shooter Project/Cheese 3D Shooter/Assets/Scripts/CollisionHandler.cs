using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip ("In seconds")][SerializeField] float reloadSceneMenuLoadDelay = 1f; // This will do until level loading is done for more levels and menus.
    [Tooltip ("FX prefab on player")][SerializeField] GameObject deathFX;
    [Tooltip("End Level Menu UI on player")] [SerializeField] GameObject endLevelMenu;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", reloadSceneMenuLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene() // string referenced
    {
        //SceneManager.LoadScene(1); // Old code that I may go back to.
        endLevelMenu.SetActive(true); // Set End Level Menu active.
        // Stop/pause timeline & Player controls.
    }

}
