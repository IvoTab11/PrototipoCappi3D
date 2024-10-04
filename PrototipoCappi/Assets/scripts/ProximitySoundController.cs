using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySoundController : MonoBehaviour
{
    public Transform player;           // Referencia al jugador
    public float maxDistance = 50f;    // Distancia m�xima para escuchar el sonido a volumen completo
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Calcula la distancia entre el jugador y el veh�culo
        float distance = Vector3.Distance(player.position, transform.position);

        // Si la distancia es menor o igual a maxDistance, ajusta el volumen basado en la proximidad
        if (distance <= maxDistance)
        {
            float volume = 1 - (distance / maxDistance); // Volumen disminuye a medida que la distancia aumenta
            audioSource.volume = Mathf.Clamp(volume, 0f, 1f); // Asegura que el volumen est� entre 0 y 1
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // Si el sonido no se est� reproduciendo, lo activa
            }
        }
        else
        {
            // Si est� muy lejos, deja de reproducir el sonido
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}

