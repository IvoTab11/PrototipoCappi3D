using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech; // Necesario para usar KeywordRecognizer
using System.Linq;

public class DejarBasura : MonoBehaviour
{
   public GameObject contenedor;
   public GameObject dejarIndicator; // Objeto visual que representa el área de recogida

    //private bool canPickup = false;
    private bool dejar = false;

    private int reciclable;
    private int desechable;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
       //keywords.Add("recoger", () => { RecogerBasuraCommand(); });
       keywords.Add("dejar", () => { DejarBasuraCommand(); });
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
        if (other.CompareTag("ContenedorGrande")) 
        {
            dejar = true;
            Debug.Log("Camión dentro del área de descarga."); // Debug para verificar
        }
        // if(other.CompareTag("ContenedorGrande"))
        // {
        //     dejar = true;
        //     Debug.Log("Camión dentro del área de descarga.");
        // }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ContenedorGrande"))
        {
            dejar = false;
            Debug.Log("Camión fuera del área de descarga."); // Debug para verificar
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
    // void RecogerBasuraCommand()
    // {
    //     int reciclableAleatoria = Random.Range(1, 10);
    //     int desechableAleatoria = Random.Range(1, 10);
    //     if (canPickup)
    //     {
    //         Debug.Log("Comando de voz detectado: recoger");
    //         reciclable+=reciclableAleatoria;
    //         Debug.Log("Basura reciclable: "+ reciclable);
    //         desechable+=desechableAleatoria;
    //         Debug.Log("Basura desechable: "+ desechable);
    //         Destroy(basura); // Eliminar el cesto de basura
    //     }
    // }
    void DejarBasuraCommand()
    {
        if(dejar)
        {
            Debug.Log("Comando de voz detectado: dejar");
            reciclable-=reciclable;
            Debug.Log("Basura reciclable: "+ reciclable);
            desechable-=desechable;
            Debug.Log("Basura desechable: "+ desechable);
        }
    }

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
