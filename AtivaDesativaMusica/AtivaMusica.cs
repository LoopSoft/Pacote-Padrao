﻿///Ativa audio e e desativa dependendo do click do botão.
using UnityEngine;
using System.Collections;
public class AtivaMusica : MonoBehaviour {

    [SerializeField]private GameObject _musica;
    int _contador = 1;
    /// <summary>
    /// Funcao que verifica se é a primeira vez que ele clica no botão de audio se sim ele reprodus, se for o segundo click ele
    /// desativa o audio anterio e ativa o atual.
    /// </summary>
    /// <param name="Audio"></param>
    public void VerificaAudio(GameObject Audio)
    {
        if (_contador == 1)
        {
            if(_musica != null)
                _musica.GetComponent<AudioSource>().Stop();

            _musica = Audio;
            ++_contador;
            _musica.GetComponent<AudioSource>().Play();
        }
        else if (_contador == 2)
        {
            _musica.GetComponent<AudioSource>().Stop();
            _musica = Audio;
            Audio.GetComponent<AudioSource>().Play();
            _contador = 1;
        }
    }
}
