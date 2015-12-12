using UnityEngine;
using System.Collections;

public class MovTemplate : MonoBehaviour {

    //public string movType = "rotZ";
    public float speed = 1;                 //Valor positivo movimento/rotação para a direita
    public float initDelay = 0;
    private float pausedIn;

    // Use this for initialization
    void Start()
    {
        //Invoke("rotate", );
        InvokeRepeating("play", initDelay, 0.041f);
    }

    public void Update()
    {
        if (PauseGameSystem.gamePaused)
        {
            pausedIn = PauseGameSystem.timeWhenPaused;
            CancelInvoke("play");
        }
        else
        {
            // print(PauseGameSystem.timeWhenPaused);
            if (pausedIn != 0)
            {
                if (pausedIn - initDelay > 0)
                    InvokeRepeating("play", 0, 0.041f);
                else
                {
                    InvokeRepeating("play", initDelay - pausedIn, 0.041f);
                }

                pausedIn = 0;
            }
        }
    }

    public virtual void play() {
        
    }
}
