/// Classe Pai que possui os metodos para instanciar objeto
using UnityEngine;
using System.Collections.Generic;
public class ControleInstanciamento : MonoBehaviour {

    /// <summary>
    /// Instancia objetos usando uma lista de "BaseObjetosDoJogo"(Classe padrao para criaçao de objetos)
    /// essa funçao vai instancia todos os objetos em sequencia, nas devidas posiçoes cadastradas, e no seu devido momento,
    /// usando a variavel de "_tempoDeEspera".
    /// </summary>
    /// <param name="obj_Instanciados"></param> Objetos para instanciar
    /// <param name="_posicaos"></param> Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param> Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(List<BaseObjetosDoJogo> obj_Instanciados, List<Vector2> _posicaos, List<float> _tempoDeEspera, List<float> _rotacao)
    {
        for (int i = 0; i < obj_Instanciados.Count; ++i) {
            yield return new WaitForSeconds(_tempoDeEspera[i]);
            Instantiate(obj_Instanciados[i],_posicaos[i],Quaternion.Euler(transform.rotation.x,transform.rotation.y,_rotacao[i]));
        }
    }
    /// <summary>
    /// Instancia objetos usando uma lista de "BaseObjetosDoJogo"(Classe padrao para criaçao de objetos)
    /// essa funçao vai instancia todos os objetos em sequencia, nas devidas posiçoes cadastradas, e no seu devido momento,
    /// usando a variavel de "_tempoDeEspera".
    /// </summary>
    /// <param name="obj_Instanciados"></param> Objetos para instanciar
    /// <param name="_posicaos"></param> Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param> Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(List<BaseObjetosDoJogo> obj_Instanciados, List<Vector3> _posicaos, List<float> _tempoDeEspera, List<float> _rotacao)
    {
        for (int i = 0; i < obj_Instanciados.Count; ++i)
        {
            yield return new WaitForSeconds(_tempoDeEspera[i]);
            Instantiate(obj_Instanciados[i], _posicaos[i], Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotacao[i]));
        }
    }
    /// <summary>
    /// Instancia objetos usando uma lista de "GameObject"
    /// essa funçao vai instancia todos os objetos em sequencia, nas devidas posiçoes cadastradas, e no seu devido momento,
    /// usando a variavel de "_tempoDeEspera".
    /// </summary>
    /// <param name="obj_Instanciados"></param> Objetos para instanciar
    /// <param name="_posicaos"></param> Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param> Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(List<GameObject> obj_Instanciados, List<Vector2> _posicaos, List<float> _tempoDeEspera, List<float> _rotacao)
    {
        for (int i = 0; i < obj_Instanciados.Count; ++i){
            yield return new WaitForSeconds(_tempoDeEspera[i]);
            Instantiate(obj_Instanciados[i], _posicaos[i], Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotacao[i]));
        }
    }
    /// <summary>
    /// Instancia objetos usando uma lista de "GameObject"
    /// essa funçao vai instancia todos os objetos em sequencia, nas devidas posiçoes cadastradas, e no seu devido momento,
    /// usando a variavel de "_tempoDeEspera".
    /// </summary>
    /// <param name="obj_Instanciados"></param> Objetos para instanciar
    /// <param name="_posicaos"></param> Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param> Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(List<GameObject> obj_Instanciados, List<Vector3> _posicaos, List<float> _tempoDeEspera, List<float> _rotacao)
    {
        for (int i = 0; i < obj_Instanciados.Count; ++i)
        {
            yield return new WaitForSeconds(_tempoDeEspera[i]);
            Instantiate(obj_Instanciados[i], _posicaos[i], Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotacao[i]));
        }
    }
    /// <summary>
    /// Instancia objetos do tipo "BaseObjetosDoJogo"(Classe padrao para criaçao de objetos)
    /// essa funçao vai instancia, na devida posiçoe cadastrada, e no seu devido momento,
    /// usando a variavel de "_tempoDeEspera". 
    /// </summary>
    /// <param name="obj_Instanciados"></param> Objetos para instanciar
    /// <param name="_posicao"></param> Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param> Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(BaseObjetosDoJogo obj_Instanciados, Vector2 _posicao, float _tempoDeEspera, float _rotacao)
    {
            yield return new WaitForSeconds(_tempoDeEspera);
            Instantiate(obj_Instanciados, _posicao, Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotacao));
    }
    /// <summary>
    /// Instancia objetos do tipo "BaseObjetosDoJogo"(Classe padrao para criaçao de objetos)
    /// essa funçao vai instancia, na devida posiçoe cadastrada, e no seu devido momento,
    /// usando a variavel de "_tempoDeEspera". 
    /// </summary>
    /// <param name="obj_Instanciados"></param> Objetos para instanciar
    /// <param name="_posicao"></param> Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param> Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(BaseObjetosDoJogo obj_Instanciados, Vector3 _posicao, float _tempoDeEspera, float _rotacao)
    {
        yield return new WaitForSeconds(_tempoDeEspera);
        Instantiate(obj_Instanciados, _posicao, Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotacao));
    }
    /// <summary>
    /// Instancia objetos do tipo "GameObject"
    /// essa funçao vai instancia, na devida posiçoe cadastrada, e no seu devido momento,
    /// usando a variavel de "_tempoDeEspera". 
    /// </summary>
    /// <param name="obj_Instanciados"></param> Objetos para instanciar
    /// <param name="_posicao"></param> Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param> Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(GameObject obj_Instanciados, Vector2 _posicao, float _tempoDeEspera, float _rotacao)
    {
        yield return new WaitForSeconds(_tempoDeEspera);
        Instantiate(obj_Instanciados, _posicao, Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotacao));
    }
    /// <summary>
    /// Instancia objetos do tipo "GameObject"
    /// essa funçao vai instancia, na devida posiçoe cadastrada, e no seu devido momento,
    /// usando a variavel de "_tempoDeEspera". 
    /// </summary>
    /// <param name="obj_Instanciados"></param>Objetos para instanciar
    /// <param name="_posicao"></param>Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param>Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(GameObject obj_Instanciados, Vector3 _posicao, float _tempoDeEspera, float _rotacao)
    {
        yield return new WaitForSeconds(_tempoDeEspera);
        Instantiate(obj_Instanciados, _posicao, Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotacao));
    }
    /// <summary>
    /// Instancia objetos do tipo "BaseObjetosDoJogo"(Classe padrao para criaçao de objetos)
    /// essa funçao vai instancia, na devida posiçoe cadastrada só que essa posicao é dada apartir de uma string(Up, Down, Right, Left, Random),
    /// e no seu devido momento,usando a variavel de "_tempoDeEspera". 
    /// </summary>
    /// <param name="obj_Instanciados"></param> Objetos para instanciar
    /// <param name="_posicaos"></param> Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param> Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(List<BaseObjetosDoJogo> obj_Instanciados, List<string> _posicaos, List<float> _tempoDeEspera, List<float> _rotacao)
    {
        float MinX = 0, MaxX = 0, MinY = 0, MaxY = 0;

        for (int i = 0; i < obj_Instanciados.Count; ++i)
        {
            yield return new WaitForSeconds(_tempoDeEspera[i]);
            Instantiate(obj_Instanciados[i], new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY)), Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotacao[i]));
        }
    }
    /// <summary>
    /// Instancia objetos do tipo "GameObject"
    /// essa funçao vai instancia, na devida posiçoe cadastrada só que essa posicao é dada apartir de uma string(Up, Down, Right, Left, Random),
    /// e no seu devido momento,usando a variavel de "_tempoDeEspera".
    /// </summary>
    /// <param name="obj_Instanciados"></param> Objetos para instanciar
    /// <param name="_posicaos"></param> Posicao ou lado que o objeto vai ser instanciado
    /// <param name="_tempoDeEspera"></param> Tempo de espera do inicio do jogo ate o objeto ser instanciado
    /// <returns></returns>
    public IEnumerator<WaitForSeconds> InstanciarOBJ(GameObject obj_Instanciados, string _posicaos, float _tempoDeEspera, float _rotacao)
    {
        float MinX = 0, MaxX = 0, MinY = 0, MaxY = 0;
        yield return new WaitForSeconds(_tempoDeEspera);
        Instantiate(obj_Instanciados, new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY)), Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotacao));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Posicao"></param>
    void VerificaString(string Posicao)
    {}
}
