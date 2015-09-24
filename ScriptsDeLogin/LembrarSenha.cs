using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LembrarSenha : MonoBehaviour {

    public Banco _banco;

    public InputField _login;
    public InputField _senha;

    /// <summary>
    /// Função caso esteja usando Scrollbar
    /// </summary>
    public Scrollbar _scrollBar;
    public void Verifica()
    {
        if (_scrollBar.value == 1) SalvaSenha();
        else if (_scrollBar.value == 0) EsqueceSenha();
    }
    /// <summary>
    /// função caso esteja usando dois buttons;
    public void SalvaSenha()
    {
        _login.text = _banco._login;
        _senha.text = _banco._senha;
    }
    public void EsqueceSenha()
    {
        _login.text = "";
        _senha.text = "";
    }
    /// </summary>
}
