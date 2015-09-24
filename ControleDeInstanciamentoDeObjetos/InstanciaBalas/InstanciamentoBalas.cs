/// Essa classe apenas instancia um objeto quando o botao esquerdo do mouse é clicado
/// essa classe é derivada da "ControleInstanciamento" por isso é necessario dar a posicao onde o objeto vai ser instanciado e 
/// o tempo de espera.
using UnityEngine;
using System.Collections;
public class InstanciamentoBalas : ControleInstanciamento {

    public BaseObjetosDoJogo obj_Bala;
    public Vector2 _posicaoDaBala;
    public float _tempoEntreTiros;
    public float _rotacao;

	void Update () {
        if (Input.GetMouseButton(0)){
            StartCoroutine(InstanciarOBJ(obj_Bala,_posicaoDaBala,_tempoEntreTiros,_rotacao));
        }
	}
}
