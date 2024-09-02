using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
   public string sceneToLoad; // Name of the scene to load
    public float transitionTime = 1f; // Transition time in seconds
    private bool transitioning; // Flag to track if a transition is in progress

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player and a transition is not in progress
        if (other.CompareTag("Player") && !transitioning)
        {
            // Start the transition to the next scene
            transitioning = true;
            StartCoroutine(LoadSceneAsync());
        }
    }

    private System.Collections.IEnumerator LoadSceneAsync()
    {
        // Start loading the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Wait until the load is complete
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
