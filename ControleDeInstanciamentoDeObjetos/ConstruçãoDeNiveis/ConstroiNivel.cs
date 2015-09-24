///
using UnityEngine;
using System.Collections.Generic;

public class ConstroiNivel : ControleInstanciamento {

    public int _numeroDeNiveis = 2;
    public List<CriadorDeNiveis> _NiveisExistente;

	void Start () {
        for (int i = 0; i < _numeroDeNiveis; ++i) {
            for (int j = 0; j < _NiveisExistente[i].obj_Instanciado.Count; ++j) {
                StartCoroutine(InstanciarOBJ(_NiveisExistente[i].obj_Instanciado[j], _NiveisExistente[i]._posicoes[j], _NiveisExistente[i]._tempoDeEspera[j], _NiveisExistente[i]._rotacao[j]));
            }
        }
	}
}
