/// se o áudio que vai ser reproduzido o tempo inteiro no aplicatico esse script deve fica na camera.
/// se não deve esta no objeto que contem a cena, ou a na camera mesmo só que com as interfaces separadas por cenas.
/// ele também controla o volume atravez de uma scrollbar.
using UnityEngine;
using UnityEngine.UI;
public class ControleDeAudio : MonoBehaviour {
    
    /// <summary>
    /// volume inicial do áudio de minimo = 0 a máximo = 1
    /// </summary>
    public float _volume = 1;
    public Scrollbar _barraDoVolume;

    int _contador = 2;

    void Start()
    {
        ///coloca o valor do volume no áudio
        gameObject.GetComponent<AudioSource>().volume = _volume;
        _barraDoVolume.value = _volume;
        ///reproduz o áudio assim que iniciar a cena.
        gameObject.GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        ///essa parte ela almenta ou diminui o volume do áudio dependendo do valor da scrollbar.
        if(_barraDoVolume.value != gameObject.GetComponent<AudioSource>().volume)
        {
            gameObject.GetComponent<AudioSource>().volume = _barraDoVolume.value;
        }
    }
    /// <summary>
    /// ativa ou desativa o áudio por um botão.
    /// </summary>
    /// <param name="_objAudio"></param>
    public void AtivaDesativa(GameObject _objAudio)
    {
        if (_contador == 1 || PlayerPrefs.GetInt("flagAudio") == 1)
        {
            PlayerPrefs.SetInt("flagAudio", 2);
            _objAudio.GetComponent<AudioSource>().Play();
            ++_contador;
        }
        else if(_contador == 2 || PlayerPrefs.GetInt("flagAudio") == 2)
        {
            PlayerPrefs.SetInt("flagAudio", 1);
            _objAudio.GetComponent<AudioSource>().Stop();
            _contador = 1;
        }
    }
}
