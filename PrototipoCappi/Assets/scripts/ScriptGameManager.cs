using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptGameManager : MonoBehaviour
{
    /*Variable tipo Hud para representar el objeto Hud de nuestro juego*/
    public HUD hud;
    /*Esto declara una propiedad estatica llamada instance que permite acceder a una instancia ?nica de la clase ScriptGameManager. 
     * El acceso a la instancia es a traves de ScriptGameManager.instance.*/
    public static ScriptGameManager instance { get; private set; }
    /*Esto declara una propiedad publica llamada PuntosTotales que proporciona acceso a la variable privada puntosTotales. 
     * Esto permite a otras clases obtener el valor de puntos totales sin modificarlo directamente.*/
    public int PuntosTotalesVidrio { get { return puntosVidrio; } }
    public int PuntosTotalesCarton { get { return puntosCarton; } }

    public int PuntosTotalesPlastico { get { return puntosPlastico; } }
    public int PuntosTotalesReciclaje { get { return puntosReciclaje; } }

    public int PuntosTotalesV { get { return puntosVida; } }

    /*Esta variable privada almacena la cantidad total de desechos en el juego.*/
    private int puntosVidrio;
    /*Esta variable privada almacena la cantidad total de reciclaje en el juego.*/
    private int puntosCarton;
    /*Esta variable privada almacena la cantidad total de vida del jugador en el juego.*/
    private int puntosVida = 100;
    /*Esta variable privada almacena la cantidad total de desechos en el juego.*/
    private int puntosPlastico;
    private int puntosReciclaje;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*Este metodo se llama al comienzo de la ejecucion del juego, antes del metodo Start. 
     * Se comprueba si ya existe una instancia de ScriptGameManager y, en caso contrario, se establece esta instancia como la actual. 
     * Esto garantiza que solo haya una instancia de ScriptGameManager en la escena.*/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Mas de un GameManager en escena");
        }
    }
    /*Este metodo se utiliza para agregar puntos al puntaje total del jugador. Se suma la cantidad puntosASumar a puntosTotales,
     se actualiza la interfaz de usuario a traves de hud, y se verifica si el jugador ha alcanzado ciertos puntos en escenas especificas
     para cargar escena YouWIn*/
    public void SumarPuntosVidrio(int puntosASumar)
    {
        puntosVidrio += puntosASumar;
        Debug.Log(puntosVidrio);
        hud.ActualizarPuntosVidrio(puntosVidrio);


        /* if (SceneManager.GetActiveScene().name == "Level1" && puntosDesechos >= 1)
         {
             SceneManager.LoadScene("YouWin");
         }*/


    }
    public void SumarPuntosReciclaje(int puntosASumar)
    {
        puntosReciclaje += puntosASumar;
        Debug.Log(puntosVidrio);
        hud.ActualizarPuntosReciclaje(puntosReciclaje);

        if (puntosReciclaje >= 100)
        {
            SceneManager.LoadScene("Win");
        }


    }
    public void SumarPuntosPlastico(int puntosASumar)
    {
        puntosPlastico += puntosASumar;
        Debug.Log(puntosPlastico);
        hud.ActualizarPuntosPlastico(puntosPlastico);


        /* if (SceneManager.GetActiveScene().name == "Level1" && puntosDesechos >= 1)
         {
             SceneManager.LoadScene("YouWin");
         }*/


    }
    public void SumarPuntosCarton(int puntosASumar)
    {
        puntosCarton += puntosASumar;
        Debug.Log(puntosCarton);
        hud.ActualizarPuntosCarton(puntosCarton);


        /* if (SceneManager.GetActiveScene().name == "Level1" && puntosReciclaje >= 1)
         {
             SceneManager.LoadScene("YouWin");
         }*/


    }
    public void SumarPuntosV(int puntosASumar)
    {
        puntosVida += puntosASumar;
        Debug.Log(puntosVida);
        hud.ActualizarPuntosV(puntosVida);




    }

    /*Este m?todo se utiliza para restar puntos al puntaje total del jugador. Se suma la cantidad puntosASumar a puntosTotales,
    se actualiza la interfaz de usuario a traves de hud, y se verifica si el jugador ha alcanzado ciertos puntos en escenas especificas
    para cargar pantalla gameover.*/
    public void RestarPuntosVidrio()
    {
        puntosVidrio -= puntosVidrio;

        Debug.Log(puntosVidrio);
        hud.ActualizarPuntosVidrio(puntosVidrio);
       

    }
    public void RestarPuntosCarton()
    {
        puntosCarton -= puntosCarton;

        Debug.Log(puntosCarton);
        hud.ActualizarPuntosCarton(puntosCarton);
       

    }
    public void RestarPuntosPlastico()
    {
        puntosPlastico -= puntosPlastico;

        Debug.Log(puntosPlastico);
        hud.ActualizarPuntosPlastico(puntosPlastico);
        

    }
    public void RestarPuntosV(int puntosARestar)
    {
        puntosVida -= puntosARestar;


        Debug.Log(puntosVida);
        hud.ActualizarPuntosV(puntosVida);
        if (puntosVida <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }

    }
}
