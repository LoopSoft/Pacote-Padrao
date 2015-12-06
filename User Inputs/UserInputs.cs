///<summary>
/// Classe que identifica as interações do usuário, somente para mobile. Essa classe deve 
/// identificar as ações do usuário na tela e gerar um valor a partir do toque ou movimento.
/// Toda vez que um valor for gerado essa classe se comunica com a 'Move' gerando a movimentação do player.
/// Ex.: Quando o usuário mover o dedo de cima para baixo o valor gerado deve ser igual a 3. 
/// Ou quando ele mover da esquerda para a direita, o valor gerado deve ser 2.
/// </summary>
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class UserInputs : MonoBehaviour {

    public float sensibility = .3f;       //Sensibilidade para identificação do movimento
    public int generatedValue, oldValue;      //Valor que será enviado pra classe responsável pelo movimento
    public Move m;


    //INIT PROPERTIES
    public int GeneratedValue
    {
        get { return generatedValue; }
    }
    //END PROPERTIES

	// Use this for initialization
	void Start () {

        //Checa se a variavel m foi atribuida-------------
        Assert.IsTrue(GetComponent<Move>(), "Impossível atribuir valor a variavel m, classe Move não encontrada neste objeto.");

        if (!m)
        {
            m = GetComponent<Move>();
        }
        //------------------------------------------------
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0))
            generatedValue = input2Direction();

        if (generatedValue != oldValue)
            m.moveByInput(generatedValue, transform.position);
    }

    /// <summary>
    /// Compara o movimento do mouse com a sensibilidade desejada se for maior o valor respectivo 
    /// para a direção é gerado
    /// </summary>
    /// <returns></returns>
    int input2Direction ()
    {
        if (Input.GetAxis("Mouse X") > sensibility)
            return 2;
        else if (Input.GetAxis("Mouse X") < -sensibility)
            return 4;
        else if (Input.GetAxis("Mouse Y") > sensibility)
            return 1;
        else if (Input.GetAxis("Mouse Y") < -sensibility)
            return 3;
        else
            return 0;

        oldValue = generatedValue;
    }
}
