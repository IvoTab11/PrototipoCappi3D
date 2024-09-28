using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public float moveSpeed = 5f;      // Velocidad de movimiento
    // public float rotationSpeed = 720f; // Velocidad de rotación

    // private Vector3 movement;

    // void Update()
    // {
    //     // Capturamos el input del teclado
    //     float horizontal = Input.GetAxis("Horizontal");  // Flechas izquierda/derecha o A/D
    //     float vertical = Input.GetAxis("Vertical");      // Flechas arriba/abajo o W/S

    //     // Creamos un vector de movimiento en el plano XZ
    //     movement = new Vector3(horizontal, 0f, vertical).normalized;

    //     // Si el personaje se está moviendo hacia adelante o lateralmente
    //     if (vertical > 0 || horizontal != 0)
    //     {
    //         Vector3 direction = new Vector3(movement.x, 0f, movement.z); // Mantener el Y en 0 para evitar rotaciones verticales
    //         Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
    //         transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    //     }

    //     // Movemos el personaje
    //     transform.position += movement * moveSpeed * Time.deltaTime;
    // }
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float rotationSpeed = 720f; // Velocidad de rotación

    private Vector3 upDirection = Vector3.forward; // Dirección "arriba" inicial (adelante)

    void Update()
    {
        // Capturamos el input del teclado
        float horizontal = Input.GetAxis("Horizontal");  // Flechas izquierda/derecha o A/D
        float vertical = Input.GetAxis("Vertical");      // Flechas arriba/abajo o W/S

        // Mover el camión hacia adelante según la dirección "arriba"
        Vector3 movement = upDirection * vertical; // Mover hacia la dirección "arriba"

        // Movemos el camión según el input del jugador
        transform.position += movement * moveSpeed * Time.deltaTime;

        // Girar el camión hacia la derecha o izquierda
        if (horizontal != 0)
        {
            // Calcular la nueva dirección "arriba" girando alrededor del eje Y
            float rotationAmount = horizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationAmount, 0);

            // Actualizar la dirección "arriba" basado en la nueva rotación
            upDirection = transform.forward; // Actualiza la dirección "arriba" a la nueva orientación
        }
    }
}
