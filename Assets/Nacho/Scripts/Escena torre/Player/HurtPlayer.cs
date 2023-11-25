using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para saber cuando el jugador se ha metido en la zona de daño
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Llamamos al método que daña al jugador
            HealthManager.instance.Hurt();
        }
    }
}
