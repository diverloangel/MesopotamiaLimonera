using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //Singleton, nos sirve para crear una instancia estática del script, de tal manera que pueda ser llamado desde otros scripts
    public static HealthManager instance;

    //Variables vida actual y vida máxima del jugador
    public int currentHealth, maxHealth;

    //variables para saber cuanto eimpo seremos invencibles tras recibir daño y el contador para que esto se acabe
    public float invincibleLength = 2f;
    public float invicibleCounter;

    //Método que se llama antes de que empiece el juego
    private void Awake()
    {
        //Meto dentro de esta instancia todo lo que contiene el script
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la vida al máximo
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (invicibleCounter > 0)
        {
            invicibleCounter -= Time.deltaTime;

            for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                //si la division da par (modulo), (mathfloor es para pillar el entero más cercano)
                if (Mathf.Floor(invicibleCounter * 5f) % 2 == 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
                //el resto no es 0, es impar
                else
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);
                }
                //0 no es par o impar, al llegar a 0 se rompe lo anterior
                if (invicibleCounter <= 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
            }
        }
    }

    //Método para hacer daño al jugador
    public void Hurt()
    {
        //si el contador de invencibilidad está vacio
        if (invicibleCounter <= 0)
        {
            //Le quitamos uno de vida al jugador
            //currentHealth--;

            //El jugador muere
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //Respawneamos al jugador
                GameManager.instance.Respawn();
            }
            //Si el jugador no se muere
            else
            {
                //Le hacemos Knockback al jugador
                PlayerController.instance.Knockback();

                invicibleCounter = invincibleLength;

                //recorrer array de piezas del jugador
                for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);
                }

            }
        }
        else
        {
            //Le hacemos Knockback al jugador
            PlayerController.instance.Knockback();

            invicibleCounter = invincibleLength;

            //recorrer array de piezas del jugador
            for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                PlayerController.instance.playerPieces[i].SetActive(false);
            }
        }
    }

    //Método para resetear la vida del jugador
    public void ResetHealth()
    {
        //Ponme la vida de nuevo al máximo
        currentHealth = maxHealth;
    }
    //añadir vida al jugador
    public void AddHealth(int amountToHeal)
    {

        currentHealth += amountToHeal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
