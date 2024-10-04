using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech; // Necesario para usar KeywordRecognizer
using System.Linq;

public class RecogerBasura : MonoBehaviour
{
   //public GameObject basura;
   //public GameObject pickupIndicator; // Objeto visual que representa el área de recogida
    private GameObject currentTrash; // Almacena la referencia de la instancia de basura
    //private bool pickupIndicator = false;

    private bool canPickup = false;
    public int carton {get; set;}
    public int plastico {get; set;}
    public int vidrio {get; set;}

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    void Start()
    {
       keywords.Add("recoger", () => { RecogerBasuraCommand(); });
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
        
        if (other.CompareTag("Basura")) 
        {
            //currentTrash = other.gameObject;
            currentTrash = other.transform.root.gameObject;
            canPickup = true;
            
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Basura"))
        {
            canPickup = false;
            currentTrash = null; // Limpiar la referencia al salir del área
        }
    }

    void RecogerBasuraCommand()
    {
        int cartonAleatorio = Random.Range(1, 10);
        int plasticoAleatorio = Random.Range(1, 10);
        int vidrioAleatorio = Random.Range(1, 10);
        if (canPickup && currentTrash != null)
        {
            Debug.Log("Comando de voz detectado: recoger");
            carton+=cartonAleatorio;
            Debug.Log("Carton: "+ carton);
            ScriptGameManager.instance.SumarPuntosCarton(carton);
            plastico += plasticoAleatorio;
            Debug.Log("Plastico: "+ plastico);
            ScriptGameManager.instance.SumarPuntosPlastico(plastico);
            vidrio += vidrioAleatorio;
            Debug.Log("Vidrio: "+ vidrio);
            ScriptGameManager.instance.SumarPuntosVidrio(vidrio);
            //Destroy(basura); // Eliminar el cesto de basura
             Destroy(currentTrash);
            canPickup = false;
        }
    }
    
}
