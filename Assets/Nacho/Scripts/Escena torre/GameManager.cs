using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton, nos sirve para crear una instancia estática del script, de tal manera que pueda ser llamado desde otros scripts
    public static GameManager instance;

    //Variable para el punto de respawn
    private Vector3 respawnPosition;

    //Método que se llama antes de que empiece el juego
    private void Awake()
    {
        //Meto dentro de esta instancia todo lo que contiene el script
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //El cursor del ratón no se verá
        Cursor.visible = false;
        //El cursor queda confinado dentro de la pantalla del juego
        Cursor.lockState = CursorLockMode.Locked;
        //Inicializo el punto de respawn en la posición inicial del jugador
        respawnPosition = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para hacerle respawn al jugador
    public void Respawn()
    {
        //Llamamos a la corutina
        StartCoroutine(RespawnCo());
    }

    //Corutina
    public IEnumerator RespawnCo()
    {
        //Accedo al jugador y lo desactivo
        PlayerController.instance.gameObject.SetActive(false);

        //Desactivamos el CinemachineBrain de la cámara, para evitar que se quede estática y produzca efectos adversos
        CameraController.instance.theCMBrain.enabled = false;

        //Activamos el fundido a negro
        UIManager.instance.fadeToBlack = true;

        //Esperamos un tiempo antes de seguir, en este caso 2 segundos
        yield return new WaitForSeconds(2f);

        //Quito el fundido a negro
        UIManager.instance.fadeFromBlack = true;

        //Respawneamos al jugador en la posición de respawn
        PlayerController.instance.transform.position = respawnPosition;

        //Activamos el CinemachineBrain de la cámara de nuevo
        CameraController.instance.theCMBrain.enabled = true;

        //Resetea la vida del jugador
        HealthManager.instance.ResetHealth();

        //Accedo al jugador y lo vuelvo a activar
        PlayerController.instance.gameObject.SetActive(true);
    }

    //Método para posicionar el punto de spawn
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        //Nuestra posición de spawn, será la posición del checkpoint con el que hemos colisionado
        respawnPosition = newSpawnPoint;
    }
}
