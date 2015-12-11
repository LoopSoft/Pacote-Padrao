using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

    public static int score;
    public Text textScore, textHigh;

	// Use this for initialization
	void Start () {
        if(!textHigh)
            Debug.LogError(transform.name + ": Atribua um valor a variavel textHigh (geralmente fica no painel de GameOver)");
        if (!textScore)
            Debug.LogError(transform.name + ": Atribua um valor a variavel textScore");

        score = 0;
        textScore.text = PlayerPrefsManager.lastScore.ToString();
        //textHigh.text = PlayerPrefsManager.bestScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if(score > 0)
            textScore.text = score.ToString();
        
        if (Stopwatch.over_time) 
        {
            PlayerPrefsManager.setPlayerLastScore(score);

            if(score > PlayerPrefsManager.bestScore)
                PlayerPrefsManager.setPlayerScore(score);
        }

        textHigh.text = PlayerPrefsManager.bestScore.ToString();
    }

    public static void addScore()
    {
        score++;
    }
}
