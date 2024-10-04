using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    /*Esto declara una variable publica de tipo TextMeshProUGUI llamada puntos. 
      * Se utiliza para mostrar informaci?n textual en la interfaz de usuario del juego.*/
    public TextMeshProUGUI puntosPlastico;
    public TextMeshProUGUI puntosVidrio;
    public TextMeshProUGUI puntosCarton;
    public TextMeshProUGUI puntosV;
    public TextMeshProUGUI puntosReciclaje;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /*En el metodo update Verifica la escena activa y actualizar el texto de puntos en consecuencia.
     */
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            puntosVidrio.text = " Vidrio: " + ScriptGameManager.instance.PuntosTotalesVidrio.ToString() ;
            puntosPlastico.text = " Plastico: " + ScriptGameManager.instance.PuntosTotalesPlastico.ToString() ;
            puntosCarton.text = " Carton: " + ScriptGameManager.instance.PuntosTotalesCarton.ToString() ;
            puntosReciclaje.text = "RECICLADO:   " + ScriptGameManager.instance.PuntosTotalesReciclaje.ToString() + "/100";
            puntosV.text =  ScriptGameManager.instance.PuntosTotalesV.ToString() + " %";

            /*if (ScriptGameManager.instance.PuntosTotalesD == 10)
            {
                puntosD.text = "Enciende el Generador";
            }*/

        }



    }
    /*Este es un metodo publico que permite actualizar el texto del objeto puntos. 
     * Toma un argumento puntosTotales y establece el texto del objeto puntos en el valor de puntosTotales.*/
    public void ActualizarPuntosVidrio(int puntosTotales)
    {
        puntosVidrio.text = puntosTotales.ToString();
    }
    public void ActualizarPuntosReciclaje(int puntosTotales)
    {
        puntosReciclaje.text = puntosTotales.ToString();
    }
    public void ActualizarPuntosPlastico(int puntosTotales)
    {
        puntosPlastico.text = puntosTotales.ToString();
    }
    public void ActualizarPuntosV(int puntosTotales)
    {
        puntosV.text = puntosTotales.ToString();
    }
    public void ActualizarPuntosCarton(int puntosTotales)
    {
        puntosCarton.text = puntosTotales.ToString();
    }
}
