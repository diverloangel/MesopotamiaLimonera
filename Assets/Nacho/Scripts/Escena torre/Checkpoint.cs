using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //Variables para guardar los objetos de checkpoint encendido y apagado
    public GameObject cpOn, cpOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Para detectar si algo ha entrado en el trigger del checkpoint
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Posicionamos el punto de Spawn del jugador, pasándole al método la posición actual del checkpoint
            GameManager.instance.SetSpawnPoint(transform.position);

            //Array para guardar los checkpoints
            Checkpoint[] allCP = FindObjectsOfType<Checkpoint>();
            //Bucle para recorrer el array e ir apagando cada checkpoint guardado
            for (int i = 0; i < allCP.Length; i++)
            {
                //Para cada checkpoint guardado en el array, apágalo
                allCP[i].cpOff.SetActive(true);
                allCP[i].cpOn.SetActive(false);
            }

            //Activamos el checkpoint activo, y desactivamos el checkpoint inactivo sobre el que estamos
            cpOff.SetActive(false);
            cpOn.SetActive(true);
        }
    }
}
