using UnityEngine;
using System.Collections;

public class ManipuladorDeInformacoes : MonoBehaviour {

    public GameObject M1;
    public int _contador = 1;
    public float _tempoDeEsperaParaDesativar = 5;

    public void setInfo(GameObject bloco)
    {
        if (_contador == 1)
        {
            M1 = bloco;
            ++_contador;
            Invoke("Reset", _tempoDeEsperaParaDesativar);
        }
       else if(_contador == 2)
        {
            if (bloco == M1){ Reset(); }

            else
            {
                Materia aux = new Materia(bloco.GetComponent<Materia>());
                bloco.GetComponent<Materia>().setParams(M1.GetComponent<Materia>());
                M1.GetComponent<Materia>().setParams(aux);
                _contador = 1;
            }
        }
    }

    void Reset()
    {
        M1 = null;
        _contador = 1;
    }
}
