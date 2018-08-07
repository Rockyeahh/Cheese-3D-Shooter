using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip ("In seconds")][SerializeField] float reloadSceneMenuLoadDelay = 1f;
    [Tooltip ("FX prefab on player")][SerializeField] GameObject deathFX;
    [Tooltip("End Level Menu UI on player")] [SerializeField] GameObject endLevelMenu;
    [Tooltip("Master Timeline on player")] [SerializeField] GameObject masterTimeline;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", reloadSceneMenuLoadDelay);
        masterTimeline.SetActive(false);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene() // string referenced
    {
        //SceneManager.LoadScene(1); // Old code that I may go back to.
        endLevelMenu.SetActive(true); // Set End Level Menu active.
    }

}
