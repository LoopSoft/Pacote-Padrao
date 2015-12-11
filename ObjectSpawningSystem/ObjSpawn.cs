///<summary>
/// Instanciamento simples de objeto
/// Uso atual: quando se quer instanciar um objeto a partir de uma função/ação/evento externo 
/// </summary>

using UnityEngine;
using System.Collections;

public class ObjSpawn : MonoBehaviour {

    public GameObject[] Objects;
    public static bool canInstantiate;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canInstantiate)
            instantiateNow();
	}

    void instantiateNow()
    {
        Instantiate(Objects[Random.Range(0, Objects.Length)], randomPos(), Quaternion.identity);
        //Instantiate(Objects, randomPos(), Quaternion.identity);
        canInstantiate = false;
    }

    /// <summary>
    /// Gera uma posição aleatória dentro da visão da camera
    /// </summary>
    /// <returns></returns>
    Vector3 randomPos()
    {
        Camera cam = Camera.main;

        Vector3 screenMin = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        Vector3 screenMax = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

        return new Vector3(Random.Range(screenMin.x, screenMax.x), Random.Range(screenMin.y, screenMax.y));
    }
}
