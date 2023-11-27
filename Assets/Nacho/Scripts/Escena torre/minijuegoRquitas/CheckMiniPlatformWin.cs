using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMiniPlatformWin : MonoBehaviour
{
    public miniPlatformDelivery[] platformsToDeliver;
    public GameObject objetoRecompensa;
    public GameObject particulas;

    public static CheckMiniPlatformWin instance;
    private void Awake()
    {
        instance = this;
    }
    public void ComprobarVictoria()
    {
        int entregados = 0;
        for (int i = 0; i < platformsToDeliver.Length; i++)
        {
            if (platformsToDeliver[i].entregado)
            {
                entregados++;
            }
        }
        //Debug.Log("entregados " + entregados);
        //Debug.Log("platformstodeliver " + platformsToDeliver.Length);

        if (entregados >= platformsToDeliver.Length)
        {
            objetoRecompensa.SetActive(true);
            particulas.SetActive(true);
        }
    }
}
