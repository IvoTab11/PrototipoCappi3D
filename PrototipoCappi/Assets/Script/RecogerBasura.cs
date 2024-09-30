using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech; // Necesario para usar KeywordRecognizer
using System.Linq;

public class RecogerBasura : MonoBehaviour
{
   public GameObject basura;
   public GameObject pickupIndicator; // Objeto visual que representa el área de recogida

    private bool canPickup = false;
    //private bool dejar = false;

    // public int reciclable {get; set;}
    // public int desechable {get; set;}
    public int carton {get; set;}
    public int plastico {get; set;}
    public int vidrio {get; set;}

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    private int valorSuma = 1;
    void Start()
    {
       keywords.Add("recoger", () => { RecogerBasuraCommand(); });
       //keywords.Add("dejar", () => { DejarBasuraCommand(); });
        // Iniciar el reconocimiento de voz
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized +=  keywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }
    void  keywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el camión
        if (other.CompareTag("Finish")) 
        {
            canPickup = true;
            //Debug.Log("Camión dentro del área de recogida."); // Debug para verificar
        }
        // if(other.CompareTag("ContenedorGrande"))
        // {
        //     dejar = true;
        //     Debug.Log("Camión dentro del área de descarga.");
        // }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            canPickup = false;
            //Debug.Log("Camión fuera del área de recogida."); // Debug para verificar
        }
        // if (other.CompareTag("ContenedorGrande"))
        // {
        //     dejar = false;
        //     Debug.Log("Camión fuera del área de descarga."); // Debug para verificar
        // }
    }

    /*void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E)) // Cambia "E" por la tecla que desees
        {
            Debug.Log("Cesto de basura recogido");
            Destroy(basura); // Eliminar el cesto de basura
        }
    }*/
    void RecogerBasuraCommand()
    {
        // int reciclableAleatoria = Random.Range(1, 10);
        // int desechableAleatoria = Random.Range(1, 10);
        int cartonAleatorio = Random.Range(1, 10);
        int plasticoAleatorio = Random.Range(1, 10);
        int vidrioAleatorio = Random.Range(1, 10);
        if (canPickup)
        {
            Debug.Log("Comando de voz detectado: recoger");
            carton+=cartonAleatorio;
            Debug.Log("Carton: "+ carton);
            plastico+=plasticoAleatorio;
            Debug.Log("Plastico: "+ plastico);
            vidrio+=vidrioAleatorio;
            Debug.Log("Vidrio: "+ vidrio);
            ScriptGameManager.instance.SumarPuntosRec(valorSuma);
            Destroy(basura); // Eliminar el cesto de basura
        }
    }
    // void DejarBasuraCommand()
    // {
    //     if(dejar)
    //     {
    //         Debug.Log("Comando de voz detectado: dejar");
    //         reciclable-=reciclable;
    //         Debug.Log("Basura reciclable: "+ reciclable);
    //         desechable-=desechable;
    //         Debug.Log("Basura desechable: "+ desechable);
    //     }
    // }

    // void  keywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    // {
    //     System.Action keywordAction;
    //     if (keywords.TryGetValue(args.text, out keywordAction))
    //     {
    //         keywordAction.Invoke();
    //     }
    // }

    // void OnDestroy()
    // {
    //     // Parar el reconocimiento cuando el objeto sea destruido
    //     if (keywordRecognizer != null && keywordRecognizer.IsRunning)
    //     {
    //         keywordRecognizer.keywordRecognizer_OnPhraseRecognized -= keywordRecognizer_OnPhraseRecognized;
    //         keywordRecognizer.Stop();
    //         keywordRecognizer.Dispose();
    //     }
    // }
}
