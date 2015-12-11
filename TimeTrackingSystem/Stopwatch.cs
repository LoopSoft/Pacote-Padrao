using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stopwatch : MonoBehaviour
{
    public bool useInvoke;
    public bool useText;                  //Usar texto ou imagem. Ex.: Quando se quer fazer tipo uma loading bar

    public Image seconds_Image_bar;
    public Text seconds_Text;
    public static float second = 60;
    public float init_seconds = 60;
    public GameObject end_Game;
    public string scene_2Load_OnGO;         //Cena que irá carregar quando der gameover

    public float sec_Before_Restart = 4;

    public static bool over_time = false;

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(sec_Before_Restart);
        Application.LoadLevel(scene_2Load_OnGO);
    }

    void Start()
    {
        second = init_seconds;
        over_time = false;

        if (useInvoke)
        {
            Invoke("cronometer", 1);
        }

        if (useText && !seconds_Text)
            Debug.LogError("Por favor atribua um valor a variável seconds_Text");
        if(!useText && !seconds_Image_bar)
            Debug.LogError("Por favor atribua um valor a variável seconds_Image_Bar");
    }
    void Update()
    {
        if (!useInvoke)
        {
            if (!over_time)
            {
                if (second > 0 && !PauseGameSystem.gamePaused)
                    second -= Time.deltaTime;
                else if(second < 0)
                {
                    over_time = true;
                    end_Game.SetActive(true);
                    StartCoroutine(RestartGame());
                }
            }

            showSecUI();
        }
        else
        {
            if (PauseGameSystem.gamePaused)
                CancelInvoke("cronometer");
            else
                Invoke("cronometer", 1);
        }
    }

    void cronometer()
    {
        if (second > 0)
            second--;
        else
        {
            over_time = true;
            end_Game.SetActive(true);
            StartCoroutine(RestartGame());
        }

        showSecUI();
    }

    void showSecUI() {
        if (useText)
            seconds_Text.text = second.ToString("f0");
        else 
            seconds_Image_bar.fillAmount = (second/init_seconds);
    }
}
