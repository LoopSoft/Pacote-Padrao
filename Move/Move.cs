///<summary>
/// Este script recebe um valor qualquer que representará a direção em que o objeto se movimentará, 
/// sendo, 1 - cima, 2 - direita, 3 - baixo, 4 - esquerda. Existirão duas formas de uso para essa classe, 
/// sendo a primeira por intervenção externa: Quando aplicada a um objeto que necessita que uma outra classe
/// controle o movimento do objeto.
/// A segunda por geração automática e aleatória: Quando há necessidade que o objeto se mova aleatóriamente 
/// de tempos em tempos.
/// </summary>
using UnityEditor;
using UnityEngine;
using System.Collections;

//Custom Inspector variables
[CustomEditor(typeof(Move)), CanEditMultipleObjects]
public class moveEditor : Editor
{
    private SerializedObject m_Object;
    private SerializedProperty m_Property;

    void OnEnable()
    {
        m_Object = new SerializedObject(target);
    }

    public override void OnInspectorGUI()
    {
        var move = target as Move;
        move.isRandom = GUILayout.Toggle(move.isRandom, "Is Random?");
        if (move.isRandom)
        {
            move.movFreq = EditorGUILayout.FloatField("Mov Freq", move.movFreq);

            m_Property = m_Object.FindProperty("rangeDir");
            EditorGUILayout.PropertyField(m_Property, new GUIContent("MyLabel"), true);
            m_Object.ApplyModifiedProperties();
        }

        move.hasLimitations = GUILayout.Toggle(move.hasLimitations, "Has limitations?");
        if (move.hasLimitations)
        {
            move.Max = EditorGUILayout.Vector2Field("XY Max", move.Max);
            move.Min = EditorGUILayout.Vector2Field("XY Min", move.Min);
        }

        move.stepSize = EditorGUILayout.FloatField("Step Size", move.stepSize);
    }
}

public class Move : MonoBehaviour {

    public bool isRandom;           //É movimento gerado automáticamente ou controlado por uma classe externa
        public float movFreq ;      //Intervalo de movimento 

    public bool hasLimitations;     //Existe limitação no mapa
        public Vector2 Max,Min;     //Maxima e mínima posição que o objeto pode se movimentar

    public float stepSize = 1;          //Quanto o objeto deve se mover
    public int[] rangeDir = {1,5};         //Intervalo de direção Ex.: rangeDir[0] = 1, rangeDir[1] = 5; será sorteado aleatóriamente um valor entre 1 e 4

	// Use this for initialization
	void Start () {
        if(isRandom && movFreq != 0)
            InvokeRepeating("randomMove", 1, movFreq);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isRandom && IsInvoking("randomMove"))
            CancelInvoke("randomMove");
	}

    //INIT METODS
    /// <summary>
    /// Gera um número aleatório para movimento
    /// </summary>
    void randomMove ()
    {
        int direction = Random.Range(rangeDir[0], rangeDir[1]);

        moveByInput(direction);
        //print(direction + " - " + transform.position);
    }

    /// <summary>
    /// Movimenta para uma direção dependendo da entrada
    /// </summary>
    /// <param name="direction"></param> direção em que o objeto se movimentará: 1 = Cima, 2 = Direita, 3 = Baixo, 4 = Esquerda
    public void moveByInput(int direction)
    {
        switch (direction)
        {
            case 1:
                if(transform.position.y < Max.y)
                    transform.Translate(new Vector3(0, 1, 0));

                break;
            case 2:
                if (transform.position.x < Max.x)
                    transform.Translate(new Vector3(1, 0, 0));

                break;
            case 3:
                if (transform.position.y > Min.y)
                    transform.Translate(new Vector3(0, -1, 0));

                break;
            case 4:
                if (transform.position.x > Min.x)
                    transform.Translate(new Vector3(-1, 0, 0));

                break;
        }
    }
    //END METODS
}
