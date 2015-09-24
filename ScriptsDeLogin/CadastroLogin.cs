using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CadastroLogin : MonoBehaviour {

    public Banco _banco;

    public InputField _login;
    public InputField _senha;
    public InputField _email;

    public GameObject _cenaDeCadastro;
    public GameObject _proximaCena;

    public GameObject _msgErro;
    public Text _textMsgErro;
    public string _msgDeErro;

    public void cadastra()
    {
        if (_login.text != "" && _senha.text != "" && _email.text != "")
        {
            _banco._login = _login.text;
            _banco._senha = _senha.text;
            _banco._email = _email.text;

            _proximaCena.SetActive(true);
            _cenaDeCadastro.SetActive(false);
        }
        else if (_login.text == "" && _senha.text == "" && _email.text == "")
        {
            _msgErro.SetActive(true);
            _textMsgErro.text = _msgDeErro;
        }
    }
}
