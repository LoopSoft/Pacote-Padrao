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

#if UNITY_EDITOR
using UnityEditor;

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

        move.isRealtimeMov = EditorGUILayout.Toggle("Real Time Mov?", move.isRealtimeMov);

        move.isRandom = GUILayout.Toggle(move.isRandom, "Is Random?");
        if (move.isRandom)
        {
            move.movFreq = EditorGUILayout.FloatField("Mov Freq", move.movFreq);

            if (!move.isRealtimeMov)
            {
                move.stepSize = EditorGUILayout.FloatField("Step Size", move.stepSize);

                m_Property = m_Object.FindProperty("rangeDir");
                EditorGUILayout.PropertyField(m_Property, new GUIContent("Direções "), true);
                m_Object.ApplyModifiedProperties();
            }
            else
            {
                move.speed = EditorGUILayout.FloatField("speed", move.speed);
            }
        }
        else
        {
            if (!move.isRealtimeMov)
            {
                move.stepSize = EditorGUILayout.FloatField("Step Size", move.stepSize);
            }
            else
            {
                move.speed = EditorGUILayout.FloatField("speed", move.speed);
            }
        }

        move.hasLimitations = GUILayout.Toggle(move.hasLimitations, "Has limitations?");
        if (move.hasLimitations)
        {
            move.Max = EditorGUILayout.Vector2Field("XY Max", move.Max);
            move.Min = EditorGUILayout.Vector2Field("XY Min", move.Min);
        }

        
    }
}
#endif

public class Move : MonoBehaviour {

    public bool isRandom;           //É movimento gerado automáticamente ou controlado por uma classe externa
        public float movFreq ;      //Intervalo de movimento 

    public bool hasLimitations;     //Existe limitação no mapa
        public Vector2 Max,Min;     //Maxima e mínima posição que o objeto pode se movimentar

    public bool isRealtimeMov;      //Flag que indica se o movimento do objeto vai ser por turno (celula/celula) ou em tempo real (aplicando velocidade em x e y)
        public float stepSize = 1, speed;          //Quanto o objeto deve se mover velocidade de movimento etc
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
    public void randomMove ()
    {
        if (movFreq > .8f)
            movFreq -= .1f;

        int direction = Random.Range(rangeDir[0], rangeDir[1]);

        moveByInput(direction);
        //print(direction + " - " + transform.position);
    }

    /// <summary>
    /// Movimenta para uma direção dependendo da entrada
    /// Aconselhável para uso em jogos de turno.
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

    /// <summary>
    /// Movimenta para uma direção dependendo da entrada
    /// Aconselhável para uso em jogos de movimento em tempo real.
    /// </summary>
    /// <param name="direction"></param> direção em que o objeto se movimentará: 1 = Cima, 2 = Direita, 3 = Baixo, 4 = Esquerda
    public void realtimeMoveByInput(float x, float y)
    {
        transform.Translate(new Vector3(x * Time.deltaTime * speed, y * Time.deltaTime * speed, 0));
    }
    //END METODS
}
