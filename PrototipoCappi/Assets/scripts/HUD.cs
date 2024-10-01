using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    /*Esto declara una variable publica de tipo TextMeshProUGUI llamada puntos. 
      * Se utiliza para mostrar informaci?n textual en la interfaz de usuario del juego.*/
    public TextMeshProUGUI puntosR;
    public TextMeshProUGUI puntosD;
    public TextMeshProUGUI puntosRec;
    public TextMeshProUGUI puntosV;


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
            puntosD.text = " Desechos: " + ScriptGameManager.instance.PuntosTotalesD.ToString() + "/10";
            puntosR.text = " Reciclado: " + ScriptGameManager.instance.PuntosTotalesR.ToString() + "/10";
            puntosRec.text = " Recoger: " + ScriptGameManager.instance.PuntosTotalesRec.ToString() + "/10";

            puntosV.text =  ScriptGameManager.instance.PuntosTotalesV.ToString() + "%";

            /*if (ScriptGameManager.instance.PuntosTotalesD == 10)
            {
                puntosD.text = "Enciende el Generador";
            }*/

        }



    }
    /*Este es un metodo publico que permite actualizar el texto del objeto puntos. 
     * Toma un argumento puntosTotales y establece el texto del objeto puntos en el valor de puntosTotales.*/
    public void ActualizarPuntosD(int puntosTotales)
    {
        puntosD.text = puntosTotales.ToString();
    }
    public void ActualizarPuntosR(int puntosTotales)
    {
        puntosR.text = puntosTotales.ToString();
    }
    public void ActualizarPuntosV(int puntosTotales)
    {
        puntosV.text = puntosTotales.ToString();
    }
    public void ActualizarPuntosRec(int puntosTotales)
    {
        puntosRec.text = puntosTotales.ToString();
    }
}
