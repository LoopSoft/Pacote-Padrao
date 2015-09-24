/// <summary>
/// Retorna cena.
/// Serve para voltar uma cena usando a tecla "escape" do celular ou um botao na cena;
/// </summary>
using UnityEngine;
using System.Collections;
public class RetornaCena : MonoBehaviour 
{
	//Variavei para informa se essa e a primeira cena que deve ser asionado a mensagem para sair se for clicado em 'escape".
	public bool PrimeiraCena = false;
	//Objeto com a mensagem para sair.
	public GameObject MensagemParaSairDoAplicativo;
	//cenas atual e a cena que deve retorna quando for clicado no botao ou no "escape".
	public GameObject CenaAtual, CenaAnterior;

	void Update () 
	{
		StartCoroutine(RetornaComEscape());
	}
	/// <summary>
	/// Retornas the COM escape.
	/// funçao com o intuito de retorna uma cena usando o botao "escape' do celular.
	/// </summary>
	IEnumerator RetornaComEscape()
	{
		if(Input.GetKeyUp(KeyCode.Escape) && PrimeiraCena == false)
		{
			CenaAtual.SetActive(false);
			CenaAnterior.SetActive(true);
			yield return new WaitForSeconds(0.3f);
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && PrimeiraCena == true)
		{
			MensagemParaSairDoAplicativo.SetActive(true);
			yield return new WaitForSeconds(0.1f);
		}
	}
	/// <summary>
	/// Retornas the COM botao.
	/// funçao com o intuito de retorna uma cena usando um botao qualquer na tela.
	/// </summary>
	public void RetornaComBotao(){
		CenaAtual.SetActive(false);
		CenaAnterior.SetActive(true);
	}
	/// <summary>
	/// Quit this instance.
	/// funçao para sair do aplicativo.
	/// usado na tela de mensagem de sair.
	/// </summary>
	public void Quit()
	{
		Application.Quit();
	}
}
