using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibirDano : MonoBehaviour
{
    private int valorRestaAuto = 10;
    private int valorRestaCamion = 30;
    private int valorSumaAmbulancia = 15;



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
        if (other.gameObject.CompareTag("Auto"))
        {
            ScriptGameManager.instance.RestarPuntosV(valorRestaAuto);
            //Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Camion"))
        {
            ScriptGameManager.instance.RestarPuntosV(valorRestaCamion);
            //Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Ambulancia"))
        {
            ScriptGameManager.instance.SumarPuntosV(valorSumaAmbulancia);
            //Destroy(this.gameObject);
        }


    }
}