/// <summary>
/// 	
/// Base objetos do jogo.
/// 
/// Classe basica para construçao de objetos do jogos.
/// 
/// Funçao: especificar oque todos objetos tem em comum mesmo que em alguns casos os objetos nao usem tudo,
/// armazena as caracteristicas dos objetos. 
/// 
/// Abstraçao: essa classe ela e a classe PAI, dela vai ser gerada outras classes filhas que vao ser as classificaçoes de objetos dos jogos.
/// 
/// OBS: ESSE SCRIPT NAO PRECISA ESTA EM NENHUM OBJETO, ELE E APENAS UMA CLASSE ABSTRATA!!
/// 
/// </summary>
using UnityEngine;
using System.Collections;
public class BaseObjetosDoJogo : MonoBehaviour {

	public int _hpReal = 0;
	public int _level = 0;
	public int _perdaDeHpPorHit = 2;//Valor de perda de Hp por hit da Bala.

	public float _velocidade = 3;

	internal int _hpInicial = 0;
	
	void Start(){_hpInicial = _hpReal;}
	/// <summary>
	/// Tipos para trabalhar com as variaveis dessa classe externamente.
	/// Hp, Level, PerdaDeHpPorHit, Velocidade.
	public int HP{
		get{return _hpReal;}
		set{_hpReal = value;}
	}
	public int Level{
		get{return _level;}
		set{_level = value;}
	}
	public int PerdaDeHpPorHit{
		get{return _perdaDeHpPorHit;}
		set{_perdaDeHpPorHit = value;}
	}
	public float Velocidade{
		get{return _velocidade;}
		set{_velocidade = value;}
	}
	/// </summary>
}