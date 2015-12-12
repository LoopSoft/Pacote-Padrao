///<summary>
/// Esta classe controla as preferências do jogador como: Pontuação (ultima/melhor) e conf de controle.
/// </summary>
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsManager : MonoBehaviour {

    public static int bestScore;
    public static int lastScore;
    public static int inputType;

    //Provavelmente eu vá substituir isso, ou passar a responsabilidade para outra classe
    //ta muito específico
    public Toggle[] tgInput;         

	// Use this for initialization
	void Start () {
        getPlayerPrefs();

        if (tgInput.Length > 0)
        {
            if (inputType == 1)
            {
                tgInput[0].isOn = false;
                tgInput[1].isOn = true;
            }
            else
            {
                tgInput[0].isOn = true;
                tgInput[1].isOn = false;
            }
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
	
	// Update is called once per frame
	void Update () {
        if (Stopwatch.over_time)
            getPlayerPrefs();
	}

    //INIT METODS
    void getPlayerPrefs()
    {
        bestScore = PlayerPrefs.GetInt("best");
        lastScore = PlayerPrefs.GetInt("last");
        inputType = PlayerPrefs.GetInt("IType");
    }

    public static void setPlayerScore(int value)
    {
        PlayerPrefs.SetInt("best", value);
    }
    public static void setPlayerLastScore(int value)
    {
        PlayerPrefs.SetInt("last", value);
    }
    public void setInputType(int value)
    {
        PlayerPrefs.SetInt("IType", value);
    }
    public void switchInputMode (bool value)
    {
        //Verdadeiro = 0
        if (value)
            inputType = 0;
        else
            inputType = 1;

        setInputType(inputType);
    }
    //END METODS
}
