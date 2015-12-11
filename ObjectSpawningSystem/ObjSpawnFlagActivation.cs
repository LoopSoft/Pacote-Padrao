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
        ObjSpawn.canInstantiate = true;
        ScoreSystem.addScore();

        Destroy(gameObject);
    }
}
