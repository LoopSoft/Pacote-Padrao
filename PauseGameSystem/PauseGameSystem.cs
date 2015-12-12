using UnityEngine;
using System.Collections;

public class PauseGameSystem : MonoBehaviour {
    public static bool gamePaused;
    public static float timeWhenPaused;

    void OnEnable()
    {
        Pause();
    }

    void OnDisable()
    {
        Play();
    }

    public void Pause ()
    {
        gamePaused = true;
        timeWhenPaused = Time.time;
    }

    public void Play()
    {
        gamePaused = false;
     //   StartCoroutine(syncTime());
    }
}
