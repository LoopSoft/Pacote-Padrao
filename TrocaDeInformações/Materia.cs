using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Materia : MonoBehaviour {

    public string _idBanco;
    public string _nome;
    public string _nomeProfessor;

    public Text _textNome;
    public Text _textNomeProfessor;

    public void Update()
    {
        _textNome.text = _nome;
        _textNomeProfessor.text = _nomeProfessor;
    }

    public Materia(Materia M) {
        setParams(M);
    }

    public void setParams(Materia M) {
        _idBanco = M._idBanco;
        _nome = M._nome;
        _nomeProfessor = M._nomeProfessor;
    }
}
