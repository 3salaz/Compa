using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CutsceneManager : MonoBehaviour
{
    public float cutsceneDuration = 10f; // Duration in seconds

    void Start()
    {
        // Start the coroutine to end the cutscene after a duration
        StartCoroutine(EndCutscene());
    }

    IEnumerator EndCutscene()
    {
        // Wait for the cutscene to finish
        yield return new WaitForSeconds(cutsceneDuration);

        // Notify GameManager that the cutscene is complete
        GameManager.Instance.OnCutsceneComplete();
    }
}