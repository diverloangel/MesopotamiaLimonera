using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public float speedBetweenPictures = 2f;

    public Image blackScreen;
    public bool empiezaHistoria;

    private float fadeSpeed = 1;

    public Image Images1;
    public Image Recuadro;
    public TMP_Text texto;
    //public TMP_Text texto;
    ////public bool image2;
    //public Image Images2;
    ////public bool image3;
    //public Image Images3;
    ////public bool image4;
    //public Image Images4;
    //public int imageCurrent;

    public bool startStory;
    public bool endStory;

    public GameObject objectToActivate;
    public bool changeScene;
    public bool putblackScreen;
    public int sceneToGoTo;

    private void Start()
    {
        if (changeScene) 
        {
            StartCoroutine(nameof(WaitToSceneChange));
        }
    }
    private void Update()
    {
        if (putblackScreen) 
        {
            Images1.color = new Color(Images1.color.r, Images1.color.g, Images1.color.b, Mathf.MoveTowards(Images1.color.a, 1, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
            return; 
        }
        if (startStory)
        {
            if (Images1.color.a != 0)
            {
                Images1.color = new Color(Images1.color.r, Images1.color.g, Images1.color.b, Mathf.MoveTowards(Images1.color.a, 0, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
                Recuadro.color = new Color(Recuadro.color.r, Recuadro.color.g, Recuadro.color.b, Mathf.MoveTowards(Recuadro.color.a, 0, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
                texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, Mathf.MoveTowards(texto.color.a, 0, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
            }
            else if(endStory == false)
            {
                endStory = true;
                objectToActivate.SetActive(true);
            }
        }

        if (blackScreen.color.a == 0f && empiezaHistoria == false)
        {
            empiezaHistoria = true;
            StartCoroutine(nameof(WaitToChange));
        }
        if (empiezaHistoria == false) 
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0, fadeSpeed * Time.deltaTime)); //En el alpha, aplicamos que transicione entre dos puntos, en un cierto tiempo
        }
    }
    IEnumerator WaitToChange()
    {
        yield return  new WaitForSeconds(speedBetweenPictures);
        startStory = true;
    }
    IEnumerator WaitToSceneChange()
    {
        yield return new WaitForSeconds(speedBetweenPictures);
        putblackScreen = true;
        yield return new WaitForSeconds(speedBetweenPictures);
        SceneManager.LoadScene(sceneToGoTo);

    }

}
