using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image blackScreen;
    public float fadeSpeed = 1f;

    public bool pulsar;
    public bool pulsado;
    private void Start()
    {
        Ganapierder.win = false;
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            pulsar = true;
        }
        if (pulsar == true)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
            if (blackScreen.color.a == 1f && pulsado == false)
            {
                pulsado = true;
                StartCoroutine(nameof(WaitToChange));
            }
        }
    }

    IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
