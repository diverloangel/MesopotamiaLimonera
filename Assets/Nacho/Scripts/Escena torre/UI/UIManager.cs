using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para poder usar la UI de Unity

public class UIManager : MonoBehaviour
{
    //Singleton, nos sirve para crear una instancia estática del script, de tal manera que pueda ser llamado desde otros scripts
    public static UIManager instance;

    //Variable para acceder a la imagen en negro del fundido
    public Image blackScreen;
    //Variable control de la velocidad del fade in
    public float fadeSpeed = 2f;
    //Variables para control del fade
    public bool fadeToBlack, fadeFromBlack;



    //Método que se llama antes de que empiece el juego
    private void Awake()
    {
        //Meto dentro de esta instancia todo lo que contiene el script
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si hacemos fundido a negro
        if (fadeToBlack)
        {
            //Cambiamos la opacidad de la pantalla en negro, de transparente a totalmente opaco
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
            //Si ya hemos llegado a tope de opacidad
            if (blackScreen.color.a == 1f)
            {
                //Desactivamos el fundido a negro
                fadeToBlack = false;
            }
        }

        //Si salimos del fundido a negro
        if (fadeFromBlack)
        {
            //Cambiamos la opacidad de la pantalla en negro, de opaco a totalmente transparante
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
            //Si ya hemos llegado a tope de transparencia
            if (blackScreen.color.a == 0f)
            {
                //Desactivamos la vuelta del fundido a negro
                fadeFromBlack = false;
            }
        }
    }
}
