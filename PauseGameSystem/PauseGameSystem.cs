using UnityEngine;

public class PauseGameSystem : MonoBehaviour {
    public static bool gamePaused;

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
    }

    public void Play()
    {
        gamePaused = false;
    }
}
