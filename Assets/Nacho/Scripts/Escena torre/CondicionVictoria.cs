using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CondicionVictoria : MonoBehaviour
{
    public PlatformToDeliver[] platformsToDeliver;
    public Image blackScreen;
    public float fadeSpeed;
    private void Update()
    {
        int entregados = 0;
        if (platformsToDeliver != null) 
        {
            for (int i = 0; i < platformsToDeliver.Length; i++) 
            {
                if (platformsToDeliver[i].entregado)
                {
                    entregados++;
                }
            }
        }
        if (entregados >= platformsToDeliver.Length)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo

        }
    }
}
