///<summary>
/// Este script recebe um valor qualquer que representará a direção em que o objeto se movimentará, 
/// sendo, 1 - cima, 2 - direita, 3 - baixo, 4 - esquerda. Existirão duas formas de uso para essa classe, 
/// sendo a primeira por intervenção externa: Quando aplicada a um objeto que necessita que uma outra classe
/// controle o movimento do objeto.
/// A segunda por geração automática e aleatória: Quando há necessidade que o objeto se mova aleatóriamente 
/// de tempos em tempos.
/// </summary>
using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public bool isRandom;           //É movimento gerado automáticamente ou controlado por uma classe externa
    public float stepSize = 1;          //Quanto o objeto deve se mover

	// Use this for initialization
	void Start () {
        if(isRandom)
            InvokeRepeating("randomMove", 1, 3);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isRandom && IsInvoking("randomMove"))
            CancelInvoke("randomMove");
	}

    //INIT METODS
    void randomMove ()
    {
        int direction = Random.Range(1,5);

        moveByInput(direction, transform.position);
        print(direction + " - " + transform.position);
    }

    public void moveByInput(int direction, Vector3 initPos)
    {
        float dist;
        //Vector3 initPos = transform.position;

        switch (direction)
        {
            case 1:
                dist = Vector3.Distance(transform.position, new Vector3(initPos.x, initPos.y + stepSize, initPos.z));
                transform.Translate(new Vector3(0, dist, 0));
                break;
            case 2:
                dist = Vector3.Distance(transform.position, new Vector3(initPos.x + stepSize, initPos.y, initPos.z));
                transform.Translate(new Vector3(dist, 0, 0));
                break;
            case 3:
                dist = Vector3.Distance(transform.position, new Vector3(initPos.x, initPos.y - stepSize, initPos.z));
                transform.Translate(new Vector3(0, -dist, 0));
                break;
            case 4:
                dist = Vector3.Distance(transform.position, new Vector3(initPos.x - stepSize, initPos.y, initPos.z));
                transform.Translate(new Vector3(-dist, 0, 0));
                break;
        }
    }
    //END METODS
}
