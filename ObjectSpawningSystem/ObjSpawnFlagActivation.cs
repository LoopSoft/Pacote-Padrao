/// <summary>
/// Exemplo de ativação externa para o script ObjSpawn
/// </summary>

using UnityEngine;
using System.Collections;

public class ObjSpawnFlagActivation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Obstacle")
            ObjSpawn.canInstantiate = true;

        if (other.tag == "Player")
        {
            ScoreSystem.addScore();
            if (PlayerPrefsManager.bestScore >= 30)
                Stopwatch.second += 2f;
        }
        Destroy(gameObject);
    }
}
