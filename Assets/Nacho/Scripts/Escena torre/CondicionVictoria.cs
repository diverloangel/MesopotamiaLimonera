using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CondicionVictoria : MonoBehaviour
{
    public PlatformToDeliver[] platformsToDeliver;
    public Image blackScreen;
    public float fadeSpeed;

    public bool Victoria;

    public static CondicionVictoria Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Victoria)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
            if (blackScreen.color.a == 1f)
            {
                Victoria = false;
                StartCoroutine(nameof(waitToShowEndPhotos));
            }
        }
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
            StartCoroutine(nameof(waitToFinish));
        }
    }

    IEnumerator waitToFinish()
    {
        Contador.Instance.Pause();
        yield return new WaitForSeconds(2f);
        Victoria = true;
        PlayerController.instance.enabled = false;
    }
    IEnumerator waitToShowEndPhotos()
    {
        yield return new WaitForSeconds(2f);
        //CAMBIAR DE ESCENA
        SceneManager.LoadScene(3);
    }
}
