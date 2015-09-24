///Ativa um Objeto depois de um numero determinado de clicks em botões no jogo ou aplicativo.
using UnityEngine;
using System.Collections;
public class AtivaPorClick : MonoBehaviour {

    public GameObject _objParaAtivar;
    public int _numeroDeClickMaximo = 5;
    public bool _ativacaoPerpetua = true;

    float _clicks = 0;

	void Update (){
        StartCoroutine(Ativa_No_Tempo());
    }
    /// <summary>
    /// Metodo para tivar a propaganda, fazer isso apenas quando o numero de click for maior ou igual ao numero maximo de clicks
    /// que foi determinado no inicio
    /// </summary>
    /// <returns></returns>
    IEnumerator Ativa_No_Tempo()
    {
        if (_clicks >= _numeroDeClickMaximo)
        {
            _objParaAtivar.SetActive(true);
            _clicks = 0;
        }

        yield return null;
    }
    /// <summary>
    /// Metodo usado nos botoes que vao contar +1 para o numero de clicks, lembrando que esse codigo so funciona se esse metodo
    /// for usado
    /// </summary>
    public void Click()
    {
        ++_clicks;
    }
}
