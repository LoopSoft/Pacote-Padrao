using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    public static int bestScore;
    public static int lastScore;
    public static int inputType;

	// Use this for initialization
	void Start () {
        getPlayerPrefs();
        //setInputType(1);
	}
	
	// Update is called once per frame
	void Update () {
        if (Stopwatch.over_time)
            getPlayerPrefs();
	}

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
}
