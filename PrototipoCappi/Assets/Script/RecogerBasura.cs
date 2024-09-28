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

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
       keywords.Add("recoger", () => { RecogerBasuraCommand(); });

        // Iniciar el reconocimiento de voz
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized +=  keywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el camión
        if (other.CompareTag("Finish")) 
        {
            canPickup = true;
            Debug.Log("Camión dentro del área de recogida."); // Debug para verificar
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            canPickup = false;
            Debug.Log("Camión fuera del área de recogida."); // Debug para verificar
        }
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
        if (canPickup)
        {
            Debug.Log("Comando de voz detectado: recoger");
            Destroy(basura); // Eliminar el cesto de basura
        }
    }

    void  keywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    /*void OnDestroy()
    {
        // Parar el reconocimiento cuando el objeto sea destruido
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.OnPhraseRecognized -= OnPhraseRecognized;
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
    }*/
}
