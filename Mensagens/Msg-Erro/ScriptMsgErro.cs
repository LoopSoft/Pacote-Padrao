/// <summary>
/// Script message erro.
///
/// Esse script nao pode nunca esta no obj Msg.Erro, ele precisa ser colocado em um loga que sempre esteja ativo,
/// ele vai funcionar da seguinte forma.
/// 
/// -O programador vai ter que seta na variavel flagAtivaMessagem = true, quando encontrar um erro e colocar a messagem na scring, a messagem qua vai aparecer
/// na caixa de msg.
/// 
/// </summary>
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScriptMsgErro : MonoBehaviour {

	public static bool flagAtivaMessagem = false;
	public GameObject MessagemErro;
	public Text CaixaDeTexto;
	public static string MessagemCaixaDeTexto;

	void Update () {
		if(flagAtivaMessagem == true){
			CaixaDeTexto.text = MessagemCaixaDeTexto;//Coloca a messagem de erro.
			MessagemErro.SetActive(true);//Ativa o obj messagem de erro.
			flagAtivaMessagem = false;//desativa a flag para futuros erros.
		}
	}
}
