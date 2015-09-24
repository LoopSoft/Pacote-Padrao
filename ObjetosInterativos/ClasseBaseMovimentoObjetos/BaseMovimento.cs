/// <summary>
/// 
/// Base movimento.
/// 
/// Classe basica para construçao de movimentos dos objetos.
/// 
/// Funçao: especificar oque todos movimentos tem em comum mesmo que em alguns casos os movimentos nao usem tudo. 
/// 
/// Abstraçao: essa classe ela e a classe PAI, dela vai ser gerada outras classes filhas que vao ser os movimentos.
/// 
/// OBS: ESSE SCRIPT NAO PRECISA ESTA EM NENHUM OBJETO, ELE E APENAS UMA CLASSE ABSTRATA!!
/// 
/// </summary>
using UnityEngine;
using System.Collections;
public class BaseMovimento : MonoBehaviour {

	public float _velocidade = 5;//Velocidade do movimento
	public float _tempoDeMovimento = 0;//Variavel que guarda o tempo que o objeto vai se movimentar antes de parar por um tempo.
	public float _tempoParada = 0;//Variavel que guarda o tempo que o objeto vai ficar parado.

	public bool _ativaParada = false;//Flag que controla se o objeto vai parar depois de um tempo ou n
	
	internal virtual void Update(){}//Funçao Update interna da classe Base Movimento e derivadas, uso geral.

	/// <summary>
	/// Verificas the se tem parada.
	/// Coroutina que vai verifica se o movimento vai parar por algum momento ou nao.
	internal IEnumerator VerificaSeTemParada(float TempoParado, bool FlagDeParada){
		if(TempoParado > 0 && FlagDeParada == true)
			yield return new WaitForSeconds(TempoParado);//Faz um parada de "TempoParao" segundos. o codigo interiro para por "TempoParado" Segundos.
		else
			yield return null;
	}
	/// </summary>

	/// <summary>
	/// tipos da classe Base Movimento
	public float Velocidade{
		get{return _velocidade;}
		set{_velocidade = value;}
	}
	/// </summary>
}