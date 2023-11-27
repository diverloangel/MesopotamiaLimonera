using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private void Awake()
    {
        instance = this;
        PlayMusica1();
    }

    public AudioSource Musica1;
    public AudioSource MusicaAgua;
    public AudioSource SonidoSalto;
    public AudioSource SonidoCogerObjeto;

    public void PlayMusica1()
    {
        Musica1.Play();
    }
    public void MusicaAguaPlay()
    {
        MusicaAgua.Play();
    }
    public void MusicaAguaStop()
    {
        MusicaAgua.Stop();
    }
    public void SonidoSaltoPlay()
    {
        SonidoSalto.Play();
    }
    public void SonidoCogerObjetoPlay()
    {
        SonidoCogerObjeto.Play();
    }
}
