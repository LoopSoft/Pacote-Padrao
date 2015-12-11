///<summary>
/// Classe que identifica as interações do usuário, somente para mobile. Essa classe deve 
/// identificar as ações do usuário na tela e gerar um valor a partir do toque ou movimento. Ou identificar 
/// através de botões na interface.
/// Toda vez que um valor for gerado essa classe se comunica com a 'Move' gerando a movimentação do player.
/// Ex.: Quando o usuário mover o dedo de cima para baixo o valor gerado deve ser igual a 3. 
/// Ou quando ele mover da esquerda para a direita, o valor gerado deve ser 2.
/// </summary>

using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;

//Custom Inspector variables
[CustomEditor(typeof(UserInputEditor)), CanEditMultipleObjects]
public class UserInputEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var userI = target as UserInputs;
        userI.getInputByUI = EditorGUILayout.Toggle(userI.getInputByUI, "Control by UI?");

        if (!userI.getInputByUI)
        {
            userI.sensibility = EditorGUILayout.FloatField("Sensibility", userI.sensibility);
            userI.generatedValue = EditorGUILayout.IntField("Generated Value", userI.generatedValue);
            userI.oldValue = EditorGUILayout.IntField("Old Value", userI.oldValue);
        }
        else
        {
            userI.sensibility = EditorGUILayout.FloatField("Sensibility", userI.sensibility);
        }

        userI.m = (Move)EditorGUILayout.ObjectField("Move script", userI.m, typeof(Move), true);
    }
}
#endif

public class UserInputs : MonoBehaviour {

    public bool getInputByUI;           //Modo de entrada por interface ou por movimento de mouse ou toque
    private bool getInputEnabled;       //Modo de entrada por slide (arrastando o dedo)
    private float mouseMoveAuxX, mouseMoveAuxY;

    public float sensibility = .3f;       //Sensibilidade para identificação do movimento
    public int generatedValue, oldValue;      //Valor que será enviado pra classe responsável pelo movimento

    //-------INIT Joystick Mode---------------------------------
    public GameObject Joystick;             //Somente usado para controle por interface
    public Vector3 initPos, desloc;
    //END JM-----------------------------------------------------

    public Move m;

    public static bool PlayerMoved;

    //INIT PROPERTIES
    public int GeneratedValue
    {
        get { return generatedValue; }
    }
    //END PROPERTIES

	// Use this for initialization
	void Start () {

        //Checa se a variavel m foi atribuida-------------
        //Assert.IsTrue(GetComponent<Move>(), "Impossível atribuir valor a variavel m, classe Move não encontrada neste objeto.");

        if (getInputByUI)
        {
            if (!Joystick)
                Debug.LogError("variavel joystick não foi atribuída");
        }

        if (!m)
        {
            m = GetComponent<Move>();
        }
        //------------------------------------------------
    }
	
	// Update is called once per frame
	void Update () {
        if (!getInputByUI)
        {
            if (getInputEnabled)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    mouseMoveAuxX = 0;
                    mouseMoveAuxY = 0;
                    generatedValue = touch2Direction();
                }
            }

            if (Input.GetMouseButtonUp(0))
                getInputEnabled = true;

            if (generatedValue != oldValue)
            {
                PlayerMoved = true;
                m.moveByInput(generatedValue);
                oldValue = generatedValue;
            }
        }

        if (getInputByUI && Joystick)
            UIAnalogic2Direction();
    }

    /// <summary>
    /// Obtem um movimento por dedo (slide) e transforma em movimento do objeto
    /// </summary>
    /// <returns></returns>
    int touch2Direction()
    {
        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;      

        //print(touchDeltaPosition);

        if (touchDeltaPosition.x > sensibility)
        {
            getInputEnabled = false;
            return 2;
        }
        else if (touchDeltaPosition.x < -sensibility)
        {
            getInputEnabled = false;
            return 4;
        }
        else if (touchDeltaPosition.y > sensibility)
        {
            getInputEnabled = false;
            return 1;
        }
        else if (touchDeltaPosition.y < -sensibility)
        {
            getInputEnabled = false;
            return 3;
        }
        else
            return 0;
        
    }

    /// <summary>
    /// Compara o movimento do mouse com a sensibilidade desejada se for maior o valor respectivo 
    /// para a direção é gerado
    /// Ex.: se o jogador movimentar o mouse da esquerda para a direita ele gera o valor 2, que significa 
    /// movimento para a direita.
    /// </summary>
    /// <returns></returns>
    int mouse2Direction ()
    {
        mouseMoveAuxX += Input.GetAxis("Mouse X") * Mathf.Pow(sensibility, -1);
        mouseMoveAuxX = Mathf.Clamp(mouseMoveAuxX, -1,1);
        mouseMoveAuxY += Input.GetAxis("Mouse Y") * Mathf.Pow(sensibility, -1);
        mouseMoveAuxY = Mathf.Clamp(mouseMoveAuxY, -1, 1);

        if (mouseMoveAuxX > sensibility)
        {
            getInputEnabled = false;
            return 2;
        }
        else if (mouseMoveAuxX < -sensibility)
        {
            getInputEnabled = false;
            return 4;
        }
        else if (mouseMoveAuxY > sensibility)
        {
            getInputEnabled = false;
            return 1;
        }
        else if (mouseMoveAuxY < -sensibility)
        {
            getInputEnabled = false;
            return 3;
        }
        else
            return 0;
    }

    /// <summary>
    /// UI input, simplesmente recebe um valor e envia para a classe de movimento
    /// Aconselhável para uso quando se tem um botão para cada direção.
    /// 1 = Cima, 2 = Direita, 3 = Baixo, 4 = Esquerda.
    /// </summary>
    /// <returns></returns>
    public void UIArrow2Direction(int value)
    {
        PlayerMoved = true;
        m.moveByInput(value);
    }

    /// <summary>
    /// UI input, simplesmente recebe um valor e envia para a classe de movimento
    /// Aconselhável para uso quando se tem um botão para cada direção.
    /// 1 = Cima, 2 = Direita, 3 = Baixo, 4 = Esquerda.
    /// </summary>
    /// <returns></returns>
    public void UIAnalogic2Direction()
    {
        PlayerMoved = true;

        desloc = Joystick.transform.localPosition;

        m.realtimeMoveByInput(desloc.x, desloc.y);
    }
}
