using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Singleton, nos sirve para crear una instancia estática del script, de tal manera que pueda ser llamado desde otros scripts
    public static PlayerController instance;

    /*VARIABLES CONTROL FÍSICAS*/
    //Velocidad de movimiento
    public float moveSpeed;
    //Fuerza de salto
    public float jumpForce;
    //jumping
    public bool jumping;
    //Escala de la gravedad. Aumenta o disminuye esta, en este caso la multiplica
    public float gravityScale = 5f;

    public Vector3 moveDirection;

    public CharacterController charController;

    /*VARIABLES CONTROL CÁMARA*/
    //Variable para la cámara que vamos a usar
    private Camera theCam;
    //Para poder acceder al modelo tridimensional del personaje
    public GameObject playerModel;
    //Velocidad de rotación del personaje
    public float rotateSpeed;

    /*VARIABLES CONTROL ANIMACIÓN*/
    //Variable para acceder al componente de animator de nuestro jugador
    public Animator anim;

    //Variable para saber si el jugador está siendo noqueado
    public bool isKnocking;
    //Variable para saber durante cuanto tiempo seremos noqueados
    public float knockBackLength = .5f;
    //Contador de tiempo de noqueo
    private float knockBackCounter;
    //Variable que aplique la fuerza al salir despedidos
    public Vector2 knockBackPower;

    //piezas que conforman el personaje
    public GameObject[] playerPieces;

    //ser arrastrado
    public float directionXToBeDragged;
    public bool beDragged;

    //Método que se llama antes de que empiece el juego
    private void Awake()
    {
        //Meto dentro de esta instancia todo lo que contiene el script
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la cámara por código, asegurándonos de que siempre está presente al empezar el juego
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        //Si estamos siendo noqueados
        if (!isKnocking)
        {
            float yStore = moveDirection.y;
            //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            if (beDragged)
            {
                if ((Input.GetAxisRaw("Horizontal") <0.1f || Input.GetAxisRaw("Horizontal") > 0.1f) || (Input.GetAxisRaw("Vertical") <-0.1f || Input.GetAxisRaw("Vertical") > 0.1f))
                {
                    moveDirection = (new Vector3(moveDirection.x + directionXToBeDragged*4, moveDirection.y, moveDirection.z));

                }
                else
                {
                    moveDirection = (new Vector3(moveDirection.x + directionXToBeDragged, moveDirection.y, moveDirection.z));

                }
            }
            //Normalizamos el MoveDirection para que a la hora de movernos a la vez en los dos Inputs, no tengamos un aumento de velocidad inesperado
            moveDirection.Normalize();
            //Una vez normalizado ya podemos multiplicarlo por la moveSpeed que hemos elegido
            moveDirection = moveDirection * moveSpeed;
            moveDirection.y = yStore;

            //Comprobamos si estamos en el suelo, para que nos deje realizar un salto. (Así evitamos salto infinito)
            if (IsGrounded.instance.isGrounded)
            {
                //Para que la fuerza de la gravedad no aumente continuamente mientras estemos en el suelo
                //Si pulsamos la tecla asociada al salto en el Input Manager
                //if (jumping == false)
                //{
                //    moveDirection.y = 0f;
                //}
                if (moveDirection.y <-2)
                {
                    moveDirection.y = -1f;
                }
                if (Input.GetButtonDown("Jump") && jumping == false)
                {
                    jumping = true;
                    StartCoroutine(nameof(jumpingCoroutine));
                    MusicManager.instance.SonidoSaltoPlay();
                    //Aplicamos al jugador en el eje Y la fuerza de salto
                    moveDirection.y = jumpForce;
                }

            }
            if (IsGrounded.instance.isGrounded == false)
            {
                //moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

                //velocity.y += gravity * Time.deltaTime;
            }


            //Aquí aplicamos la fuerza de la gravedad al jugador cogiendo la gravedad que tenemos configurada desde el programa multiplicada por la escala de la gravedad
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            //transform.position = transform.position + (moveDirection * Time.deltaTime * moveSpeed);
            charController.Move(moveDirection * Time.deltaTime);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

                //Accedemos al jugador y le cambiamos su rotación, con Slerp lo hacemos más suavamente, cambiando de 0 a 90 grados por ejemplo, no de golpe, sino gradualmente conforme nos acercamos decelerando
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime); //A Slerp hay que pasarle la rotación actual, la rotación a la que queremos llegar, y la velocidad de rotación
            }
        }


        if (isKnocking)
        {
            //cuenta atras para volver a moverse
            knockBackCounter -= Time.deltaTime;

            float yStore = moveDirection.y;
            moveDirection = playerModel.transform.forward * -knockBackPower.x;
            moveDirection.y = yStore;

            if (IsGrounded.instance.isGrounded)
            {
                //Para que la fuerza de la gravedad no aumente continuamente mientras estemos en el suelo
                moveDirection.y = 0f;
            }
            //fisica
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
            //movimiento
            charController.Move(moveDirection * Time.deltaTime);

            if (knockBackCounter <= 0)
            {
                isKnocking = false;
            }
        }

        /*Programamos las animaciones*/
        //Cambiamos el valor del parámetro del Animator que se llama Speed, para que se realice la animación
        anim.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z)); //Para ello además de ver que parámetros cambiamos, le pasamos el valor que tendrá el nuevo valor, en este caso siempre devolvemos un valor positivo
        //Cambiamos el valor del parámetro Grounded. Para ello el propio character controller del jugador analiza a través de isGrounded si estamos en el suelo o no
        //anim.SetBool("Grounded", charController.isGrounded);
        anim.SetBool("Grounded", IsGrounded.instance.isGrounded);

    }

    //Método que hace Knockback al jugador
    public void Knockback()
    {
        //Estamos siendo noqueados
        isKnocking = true;
        //Inicializamos el contador
        knockBackCounter = knockBackLength;
        Debug.Log("Knocked Back");
        moveDirection.y = knockBackPower.y;
        //aplicamos moveDirection
        charController.Move(moveDirection * Time.deltaTime);
    }

    IEnumerator jumpingCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        jumping = false;
    }
}
