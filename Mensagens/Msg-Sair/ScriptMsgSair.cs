/// <summary>
/// Script message sair.
/// 
/// Esse script nao pode nunca esta no obj Msg.Sair, ele precisa ser colocado em um loga que sempre esteja ativo,
/// ele vai funcionar da seguinte forma.
/// 
/// -Basicamente se o usuario clicar em "Escape"(butao do celular que sai da maioria dos aplicativos), ele vai ativar o Objeto Messagem Sair,
/// o usuario vai ter a opçao de cancelar e volta pro aplicativo ou confirma e sair do aplicativo.
/// 
/// -Melhor forma de usar e criar um objeto no Canvas onde vai ficar guardado todas as menssagens do aplicativo, e colocar o script nesse objeto,
/// onde vai esta sempre ativado.
/// 
/// OBS: o botao de cancelar vai ser usado a funçao do unit para desativar o objeto Messagem Sair.
/// </summary>
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScriptMsgSair : MonoBehaviour {

	/// <summary>
	/// Buttons the confirma saida.
	/// funçao para ser colocada no botao que confirma a saida do usuario.
	/// </summary>
	public void ButtonConfirmaSaida()
	{
		Application.Quit();
	}

	public GameObject Msg_Sair;
	public Text CaixaDeTexto;
	public string MessagemDaCaixaDeTexto;

	void Start()
	{
		if(Input.GetKey(KeyCode.Escape))
			CaixaDeTexto.text = MessagemDaCaixaDeTexto;
			Msg_Sair.SetActive(true);
	}
}
