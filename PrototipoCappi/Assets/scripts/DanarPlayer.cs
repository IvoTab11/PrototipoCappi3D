using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanarPlayer : MonoBehaviour
{
    /*Una variable privada que almacena un valor num?rico inicializado en 1*/
    private int valorResta = 10;



    void Start()
    {

    }


    void Update()
    {

    }

    /*Este metodo se llama cuando el objeto colisiona con otro objeto en el juego. Si el objeto colisiona con un objeto que tenga la etiqueta "Jugador", 
     * se llama a la funcion SumarPuntos del script ScriptGameManager.instance, y luego se destruye el objeto.*/
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScriptGameManager.instance.RestarPuntosV(valorResta);
            //Destroy(this.gameObject);
        }

    }
}
