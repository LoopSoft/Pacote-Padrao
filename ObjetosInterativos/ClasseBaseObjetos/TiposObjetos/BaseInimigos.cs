﻿/// <summary>
/// 
/// Base inimigos.
/// 
/// Classe basica para construçao das Inimigos e Obstaculos do jogo.
/// 
///	Funçao: especificar as caracteristicas dos diferentes tipos de Inimigos.
/// 
/// Abstraçao: essa classe ela e a classe FILHA_1, dela vai ser gerada outras classes filhas que vao ser as classificaçoes dos Inimigos do jogo.
/// 
/// OBS: 
/// 	1 - ESSE SCRIPT NAO PRECISA ESTA EM NENHUM OBJETO, ELE E APENAS UMA CLASSE ABSTRATA!!
/// 	2 - Necessita da criaçao da tag(Player, Bullet).
/// 	3 - Essa classe precisa trabalhar em conjunto com a responsavel do controle de PONTOS, MOEDAS E EXP do jogador.
/// 
/// </summary>
using UnityEngine;
using System.Collections;
public class BaseInimigos : BaseObjetosDoJogo {

	public string _tagJogador = "Player";//Armazena o valor da tag usada para referenciar um Objeto Jogador.
	public string _tagBalaPersonagem = "BulletDoPersonagem";//Armazena o valor da tag usada para referenciar um Objeto Bala Inimiga.

	public int _ganhoDeExp = 0;//Quando aquele objeto da de XP para o jogador.
	public int _ganhoDePontos = 0;//Quando aquele objeto da de Pontos para o jogador.
	public int _ganhoDeMoedas = 0;//Quando aquele objeto da de Moedas para o jogador.

	public int _porcentagemDeChanceDeSairUmPowerUp = 10;
	public bool _possuiPowerUp = false;//flag que verifica se esse objeto pode gerar um power-up.
	public GameObject _powerUpObjeto;

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == _tagJogador){
			Destroy(gameObject);
		}
		else if(other.gameObject.tag == _tagBalaPersonagem){
			if(this._hpReal <= this._perdaDeHpPorHit){
				this._hpReal = 0;
				//coroutine que vai lançar um power up se esse objeto tiver um power up.
				//coroutine que vai contar os pontos e moedas e exp que esse objeto da pra o jogador.
				StartCoroutine(InstanciaPowerUp());
				Destroy(gameObject);
			}
			else if(this._hpReal > this._perdaDeHpPorHit){
				this._hpReal -= this._perdaDeHpPorHit;
			}
		}
	}
	/// Coroutina com a funçao de verificar se possui um power up e se ele conseguiu o valor certo para que o poder seja usado.
	IEnumerator InstanciaPowerUp()
	{
		if(_possuiPowerUp == true && Random.Range(1, 100) <= _porcentagemDeChanceDeSairUmPowerUp){
			Instantiate(_powerUpObjeto, gameObject.transform.position, Quaternion.identity);
		}
		else{
			yield return null;
		}
	}
	/// <summary>
	/// Tipos para trabalhar com as variaveis dessa classe externamente.
	/// GanhoDeExp, GanhoDePontos, GanhoDeMoedas, PerdaDeHpPorHit.
	public int GanhoDeExp{
		get{return _ganhoDeExp;}
	}
	public int GanhoDePontos{
		get{return _ganhoDePontos;}
	}
	public int GanhoDeMoedas{
		get{return _ganhoDeMoedas;}
	}
	/// <summary>
}