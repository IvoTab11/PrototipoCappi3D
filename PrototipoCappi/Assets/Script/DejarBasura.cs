using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech; // Necesario para usar KeywordRecognizer
using System.Linq;

public class DejarBasura : MonoBehaviour
{
   public GameObject contenedor;
   public GameObject dejarIndicator; // Objeto visual que representa el área de recogida

    // private bool puedeReciclar = false;
    // private bool puedeDesechar = false;
    private bool tirarCarton = false;
    private bool tirarPlastico = false;
    private bool tirarVidrio = false;

     // Referencia al script RecogerBasura
    private RecogerBasura recogerBasura;

    // private int reciclable;
    // private int desechable;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    private int valorSuma = 1;
    void Start()
    {
        // Encontrar el script RecogerBasura
        recogerBasura = FindObjectOfType<RecogerBasura>();
        
    //    keywords.Add("reciclar", () => { ReciclarCommand(); });
    //    keywords.Add("desechar", () => { DesecharCommand(); });
       keywords.Add("carton", () => { CartonCommand(); });
       keywords.Add("plastico", () => { PlasticoCommand(); });
       keywords.Add("vidrio", () => { VidrioCommand(); });

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
        // if (other.CompareTag("Carton")) 
        // {
        //     tirarCarton = true;
        //    // Debug.Log("Camión dentro del área de descarga."); // Debug para verificar
        // }else if(other.CompareTag("Plastico")){
        //     tirarPlastico = true;
        // }else{
        //     tirarVidrio= true;
        // }
        if (other.CompareTag("Carton")) 
        {
            tirarCarton = true;
            tirarPlastico = false;
            tirarVidrio = false;
        }
        else if(other.CompareTag("Plastico"))
        {
            tirarPlastico = true;
            tirarCarton = false;
            tirarVidrio = false;
        }
        else if(other.CompareTag("Vidrio"))
        {
            tirarVidrio = true;
            tirarCarton = false;
            tirarPlastico = false;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        // if (other.CompareTag("Carton"))
        // {
        //     //dejar = false;
        //     // puedeDesechar = false;
        //     // puedeReciclar = false;
        //     tirarCarton = false;
        //     //Debug.Log("Camión fuera del área de descarga."); // Debug para verificar
        // }else if(other.CompareTag("Plastico")){
        //     tirarPlastico = false;
        // }else{
        //     tirarVidrio= false;
        // }
        if (other.CompareTag("Carton"))
        {
            tirarCarton = false;
        }
        else if(other.CompareTag("Plastico"))
        {
            tirarPlastico = false;
        }
        else if(other.CompareTag("Vidrio"))
        {
            tirarVidrio = false;
        }
    }

    
    void CartonCommand(){
        if(tirarCarton && recogerBasura.carton!=0){
            Debug.Log("Comando de voz detectado: carton");
            recogerBasura.carton-=recogerBasura.carton;
            ScriptGameManager.instance.SumarPuntosD(valorSuma);
            Debug.Log("Carton: "+ recogerBasura.carton);
        }
    }
    void PlasticoCommand(){
        if(tirarPlastico && recogerBasura.plastico!=0){
            Debug.Log("Comando de voz detectado: plastico");
            recogerBasura.plastico-=recogerBasura.plastico;
            ScriptGameManager.instance.SumarPuntosD(valorSuma);
            Debug.Log("Plastico: "+ recogerBasura.plastico);
        }
    }
    void VidrioCommand(){
        if(tirarVidrio && recogerBasura.vidrio!=0){
            Debug.Log("Comando de voz detectado: vidrio");
            recogerBasura.vidrio-=recogerBasura.vidrio;
            ScriptGameManager.instance.SumarPuntosD(valorSuma);
            Debug.Log("Vidrio: "+ recogerBasura.vidrio);
        }
    }

   

}
