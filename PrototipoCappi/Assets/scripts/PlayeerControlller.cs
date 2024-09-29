using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Referencia al CharacterController responsable del movimiento del jugador.
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -9.81f;

    private Vector3 velocity;

    private void Start()
    {

    }

    private void Update()
    {
         // Verificar si el jugador está en el suelo
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Asegurar que el jugador se mantenga pegado al suelo
        }
        // Obtener la entrada del eje horizontal (teclas A y D o flechas izquierda y derecha).
        float x = Input.GetAxis("Horizontal");

        // Obtener la entrada del eje vertical (teclas W y S o flechas arriba y abajo).
        float z = Input.GetAxis("Vertical");

        // Crear un vector de movimiento en función de la entrada del jugador.
        Vector3 move = transform.right * x + transform.forward * z;
        // Mover el jugador en la dirección calculada.
        controller.Move(move*speed*Time.deltaTime);

        // Aplicar gravedad
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2f; // Resetear la velocidad vertical si está en el suelo
        }

        // Aplicar el movimiento vertical
        controller.Move(velocity * Time.deltaTime);
    }
}
