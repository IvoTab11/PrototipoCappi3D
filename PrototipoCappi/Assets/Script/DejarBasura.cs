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
    //private bool dejar = false;
    private bool puedeReciclar = false;
    private bool puedeDesechar = false;

     // Referencia al script RecogerBasura
    private RecogerBasura recogerBasura;

    // private int reciclable;
    // private int desechable;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
        // Encontrar el script RecogerBasura
        recogerBasura = FindObjectOfType<RecogerBasura>();
        
       //keywords.Add("recoger", () => { RecogerBasuraCommand(); });
       //keywords.Add("dejar", () => { DejarBasuraCommand(); });
       keywords.Add("reciclar", () => { ReciclarCommand(); });
       keywords.Add("desechar", () => { DesecharCommand(); });
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
        if (other.CompareTag("Reciclable") || other.CompareTag("Desechable")) 
        {
            //dejar = true;
            puedeDesechar = true;
            puedeReciclar = true;
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
        if (other.CompareTag("Reciclable") || other.CompareTag("Desechable"))
        {
            //dejar = false;
            puedeDesechar = false;
            puedeReciclar = false;
            Debug.Log("Camión fuera del área de descarga."); // Debug para verificar
        }
        // if (other.CompareTag("ContenedorGrande"))
        // {
        //     dejar = false;
        //     Debug.Log("Camión fuera del área de descarga."); // Debug para verificar
        // }
    }

    // void DejarBasuraCommand()
    // {
    //     if(dejar)
    //     {
    //         Debug.Log("Comando de voz detectado: dejar");
    //         // reciclable-=1;
    //         // Debug.Log("Basura reciclable: "+ reciclable);
    //         // desechable-=1;
    //         // Debug.Log("Basura desechable: "+ desechable);
    //         recogerBasura.reciclable-=1;
    //         Debug.Log("Basura reciclable: "+ recogerBasura.reciclable);
    //         recogerBasura.desechable-=1;
    //         Debug.Log("Basura desechable: "+ recogerBasura.desechable);
    //     }
    // }
    void ReciclarCommand()
    {
        if(puedeReciclar && recogerBasura.reciclable!=0){
            Debug.Log("Comando de voz detectado: reciclar");
            recogerBasura.reciclable-=1;
            Debug.Log("Basura reciclable: "+ recogerBasura.reciclable);
        }
    }
    void DesecharCommand()
    {
        if(puedeDesechar && recogerBasura.desechable!=0){
            Debug.Log("Comando de voz detectado: desechar");
            recogerBasura.desechable-=1;
            Debug.Log("Basura desechable: "+ recogerBasura.desechable);
        }
    }

   

}
