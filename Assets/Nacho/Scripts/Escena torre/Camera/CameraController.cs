using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;//Importamos la librería de Cinemachine para poder trabajar con ella

public class CameraController : MonoBehaviour
{
    //Singleton, nos sirve para crear una instancia estática del script, de tal manera que pueda ser llamado desde otros scripts
    public static CameraController instance;

    //Variable para la cámara de Cinemachine
    public CinemachineBrain theCMBrain;

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
        
    }
}
