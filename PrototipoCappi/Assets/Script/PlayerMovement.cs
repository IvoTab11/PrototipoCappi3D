using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento
    public float rotationSpeed = 720f; // Velocidad de rotación

    private Vector3 movement;

    void Update()
    {
        // Capturamos el input del teclado
        float horizontal = Input.GetAxis("Horizontal");  // Flechas izquierda/derecha o A/D
        float vertical = Input.GetAxis("Vertical");      // Flechas arriba/abajo o W/S

        // Creamos un vector de movimiento en el plano XZ
        movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Si el personaje se está moviendo hacia adelante o lateralmente
        if (vertical > 0 || horizontal != 0)
        {
            Vector3 direction = new Vector3(movement.x, 0f, movement.z); // Mantener el Y en 0 para evitar rotaciones verticales
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Movemos el personaje
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
