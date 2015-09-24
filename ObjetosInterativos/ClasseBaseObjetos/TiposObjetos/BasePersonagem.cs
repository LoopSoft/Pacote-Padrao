/// <summary>
/// 
/// Base personagem.
/// 
/// Classe basica para construçao das personagens do jogo.
/// 
///	Funçao: especificar as caracteristicas dos diferentes tipos de personagens.
/// 
/// Abstraçao: essa classe ela e a classe FILHA_1, dela vai ser gerada outras classes filhas que vao ser as classificaçoes dos personagens do jogo.
/// 
/// OBS: 
/// 	1 - ESSE SCRIPT NAO PRECISA ESTA EM NENHUM OBJETO, ELE E APENAS UMA CLASSE ABSTRATA!!
/// 	2 - Necessita da criaçao da tag(Bullet, Enimy, PowerUp).
/// 
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BasePersonagem : BaseObjetosDoJogo {

	public List<BasePowerUp> PowerUp;//Variavel que armazena todos PowerUp do jogo para ser sorteado quando o jogador tocar em um obj power up.

	public string _tagBala = "Bullet";//Armazena o valor da tag usada para referenciar um Objeto Bala.
	public string _tagInimigo = "Enimy";//Armazena o valor da tag usada para referenciar um Objeto Inimigo.
	public string _tagPowerUp = "PowerUp";//Armazena o valor da tag usada para referenciar um Objeto PowerUp.
	

	public int _vidas = 3;//Valor de vidas do personagem.

	//public int _expAcumulado = 0;

	public bool _verificaSeTemPowerUpAtivo = false;//Flag que verifica se o jogador ja tem um power up.

	/// <summary>
	/// 
	/// Raises the collision enter 2D event.
	/// 
	/// Funçao responsavel por identificar qual tipo de objeto o personagem entro em contato.
	void OnCollisionEnter2D(Collision2D other)
	{
		//Ta verificando se a colisao foi feita entre um jogador e uma bala.
		if(other.gameObject.tag == _tagBala){
			if(this._hpReal <= this._perdaDeHpPorHit && _vidas > 0){
				_vidas -= 1;
				this._hpReal = this._hpInicial;
			}
			else if(this._hpReal <= this._perdaDeHpPorHit && _vidas == 0){
				this._hpReal = 0;
				//Derrota do usuario GAME OVER.
			}
			else if(this._hpReal > this._perdaDeHpPorHit && _vidas > 0){
				this._hpReal -= this._perdaDeHpPorHit;
			}
		}
		//Ta verificando se a colisao foi feita entre um jogador e um inimigo.
		else if(other.gameObject.tag == _tagInimigo){
			this._hpReal = 0;
			if(_vidas == 0){
				//Ativa o Game Over instantanio se a Vida do Jogador for Zero.
			}
			else {
				_vidas -= 1;
				this._hpReal = this._hpInicial;
			}
		}
		//Ta verificando se a colisao foi feita entre um jogador e um power up.
		else if(other.gameObject.tag == _tagPowerUp)
		{
			_verificaSeTemPowerUpAtivo = true;
			PowerUp[Random.Range(0, PowerUp.Count)].AtivaPowerUp = true;//Essa linha faz o seguinte, ela vai da um start na courotina do power up, sorteado aleatoriamente.
			Destroy(other.gameObject);
		}
	}
	/// </summary>
	/// <param name="other">Other.</param>
	///-------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Tipos para serem acessado e alterados externamente se necessario.
	public bool VerificaSeTemPowerUpAtivo{
		get{return _verificaSeTemPowerUpAtivo;}
		set{_verificaSeTemPowerUpAtivo = value;}
	}
	/// <summary>
}
