/// <summary>
/// 
/// Base power up.
/// 
/// Classe basica para construçao das PowerUp do jogo.
/// 
///	Funçao: especificar as caracteristicas dos diferentes tipos de PowerUp.
/// 
/// Abstraçao: essa classe ela e a classe FILHA_1, dela vai ser gerada outras classes filhas que vao ser as classificaçoes dos PowerUp do jogo.
/// 
/// OBS:
/// 	1 - ESSE SCRIPT NAO PRECISA ESTA EM NENHUM OBJETO, ELE E APENAS UMA CLASSE ABSTRATA!!
/// 	2 - Necessita da criaçao da tag(Player).
/// 
/// </summary>
using UnityEngine;
using System.Collections;
public class BasePowerUp : BaseObjetosDoJogo {

	public string _tagJogador = "Player";//Armazena o valor da tag usada para referenciar um Objeto Jogador.

	public float _tempoDeExecucao = 5f;//Variavel que afirma o tempo de duraçao do power up.

	public bool _ativaPowerUp = false;//flag para ativar ou desativar um power up.
	
	internal virtual void Update(){}

	/// <summary>
	/// Tipos para trabalhar com as variaveis dessa classe externamente.
	/// AtivaPowerUp.
	public bool AtivaPowerUp{
		set{_ativaPowerUp = value;}
	}
	/// <summary>


}