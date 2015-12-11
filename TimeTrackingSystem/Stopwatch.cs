using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stopwatch : MonoBehaviour
{
    public bool UseInvoke;

    public Text second_text;
    public static float second = 60;
    public GameObject end_game;
    public string scene2LoadOnGO;           //Cena que irá carregar quando der gameover

    public float secBeforeRestart = 4;

    public static bool over_time = false;

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(secBeforeRestart);
        Application.LoadLevel(scene2LoadOnGO);
    }

    void Start()
    {
        second = 60;
        over_time = false;

        if (UseInvoke)
        {
            Invoke("cronometer", 1);
        }
    }
    void Update()
    {
        if (UseInvoke)
        {
            if (!over_time)
            {
                if (second > 0)
                    second -= Time.deltaTime;
                else
                {
                    over_time = true;
                    end_game.SetActive(true);
                    StartCoroutine(RestartGame());
                }
            }

            second_text.text = second.ToString("f0");
        }
    }

    void cronometer()
    {
        if (second > 0)
            second--;
        else
        {
            over_time = true;
            end_game.SetActive(true);
            StartCoroutine(RestartGame());
        }

        second_text.text = second.ToString("f0");
    }
}
