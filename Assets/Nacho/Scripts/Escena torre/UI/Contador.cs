using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public float contadorStart;
    private float contador;
    //public float sumarRonda;

    //private bool primeraRonda = true;

    public bool canCount;

    //visual
    //public Slider barraR;
    //public Slider barraL;
    private float contadorRounded;
    //public TMP_Text textContador;
    public Text textContador;

    public bool fadeToBlack;
    public Image blackScreen;
    public float fadeSpeed;
    public Text youDied;

    public static Contador Instance;
    private void Awake()
    {
        Instance = this;
        youDied.color = new Color(youDied.color.r, youDied.color.g, youDied.color.b, 0);
    }

    private void Start()
    {
        canCount = true;
        contador = contadorStart;

        //barraR.maxValue = contador;
        //barraL.maxValue = contador;

        //barraL.value = contador;
        //barraR.value = contador;
    }

    private void Update()
    {
        //resta tiempo
        if (canCount)
        {
            contador -= Time.deltaTime;
        }
        //barraL.value = contador; barraR.value = contador;

        //redondea el contador (solo para mostrar el numero)
        contadorRounded = contador;

        contadorRounded = Mathf.RoundToInt(contador);
        var ts = TimeSpan.FromSeconds(contador);
        //textContador.text = string.Format("{0}:{1:00}:{2:00}", (int)ts.Hours, (int)ts.Minutes, (int)ts.Seconds);
        textContador.text = string.Format("{0}:{1:00}", (int)ts.Minutes, (int)ts.Seconds);
        //textContador.text = ("" + contadorRounded);

        //cambia color según el porcentaje
        ComprobarPorcentaje();

        if (fadeToBlack)
        {
            //Cambiamos la opacidad de la pantalla en negro, de transparente a totalmente opaco
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
            //Si ya hemos llegado a tope de opacidad
            if (blackScreen.color.a == 1f)
            {
                youDied.color = new Color(youDied.color.r, youDied.color.g, youDied.color.b, Mathf.MoveTowards(youDied.color.a, 1, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
                //A escena de menu
                if (youDied.color.a == 1f)
                {
                    StartCoroutine(nameof(SceneGO));
                }
            }
        }
    }
    IEnumerator SceneGO()
    {
        yield return new WaitForSeconds(fadeSpeed);
        //scenemanager
        SceneManager.LoadScene(0);
    }

    public void ComprobarPorcentaje()
    {
        //70%
        if (contador > contadorStart * 0.7f)
        {
            CambiarColor(Color.white);
        }
        if (contador < contadorStart * 0.7)
        {
            CambiarColor(Color.yellow);
        }
        //30%
        if (contador < contadorStart * 0.3f)
        {
            CambiarColor(Color.red);
        }
        //0%
        if (contador <= 0)
        {
            textContador.text = ("0:00");
            //ONFAIL
            //GameEvents.Instance.FailHit();
            fadeToBlack = true;
        }

    }

    private void CambiarColor(Color color)
    {
        //barraL.fillRect.GetComponent<Image>().color = color;
        //barraR.fillRect.GetComponent<Image>().color = color;
        textContador.color = color;
    }


    public void SumarRonda()
    {
        //if (GameController.Instance.primeraRonda == false)
        //{
        //    contador += sumarRonda;
        //}
    }

    public void Pause()
    {
        canCount = false;
    }
    public void RestartLevel()
    {
        //FUNCION CONTINUAR CUANDO PIERDES
        Start(); //reinicia el tiempo del nivel
        canCount = true;
    }
    public void Continue()
    {
        //FUNCION CONTINUAR SIN PERDER,
        //Esto es así para que entre que sale una rueda y se pone otra
        //no te cuente el tiempo, porque sería injusto para la jugadora
        canCount = true;
    }
}
