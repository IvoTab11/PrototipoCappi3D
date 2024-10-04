using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDisposalSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Detecta cuando cualquier cosa entra en el contenedor
    void OnTriggerEnter(Collider other)
    {
        // Reproduce el sonido cuando algo entra en el contenedor
        audioSource.Play();
    }
}

