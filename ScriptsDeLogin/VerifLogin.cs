using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class VerifLogin : MonoBehaviour {

    public Banco _banco;

    public InputField _login;
    public InputField _senha;

    public GameObject _cenaDeLogin;
    public GameObject _proximaCena;

    public GameObject _msgErro;
    public Text _textMsgErro;
    public string _msgDeErro;

    public void Verif()
    {
        if(_login.text == _banco._login && _senha.text == _banco._senha)
        {
            _proximaCena.SetActive(true);
            _cenaDeLogin.SetActive(false);
        }
        else if(_login.text != _banco._login || _senha.text != _banco._senha || _login.text == "" || _senha.text == "" || _login.text == null || _senha.text == null)
        {
            _msgErro.SetActive(true);
            _textMsgErro.text = _msgDeErro;
        }
    }
}
