///Controla a ativação dos áudios por click.
using UnityEngine;
public class AtivaMusica : MonoBehaviour {

    [SerializeField]private GameObject _musica; //ARMAZENA O OBJETO(MUSICA/ÁUDIO) QUE FOI CLICADO POR ULTIMO.   

    bool _contador = true;

    /// <summary>
    /// Função responsável por gerenciar a ativação dos áudios de acordo com o objeto clicado por último.  
    /// </summary>
    /// <param name="Audio"></param>
    public void VerificaAudio(GameObject Audio)
    {
        if (_contador)
        {
            //INIT
            if (_musica != null)//PARA A REPRODUÇÃO ANTERIOR, DANDO ESPAÇO PARA O NOVO AUDIO
                _musica.GetComponent<AudioSource>().Stop(); 
            //END

            _musica = Audio;
            _contador = false;
            _musica.GetComponent<AudioSource>().Play();
        }
        else if (!_contador && _musica == Audio)
        {
            _contador = true;
        }
        else if (!_contador && _musica != Audio)
        {
            _musica.GetComponent<AudioSource>().Stop();
            _musica = Audio;
            Audio.GetComponent<AudioSource>().Play();
            _contador = true;
        }
    }
}
