using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech; // Necesario para usar KeywordRecognizer
using System.Linq;

public class RepararCamion : MonoBehaviour
{
    private bool puedeReparar = false;
     private int valorSumaAmbulancia = 30;
    public GameObject areaTaller;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    // Start is called before the first frame update
    void Start()
    {
        keywords.Add("reparar", () => { RepararCommand(); });

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
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Taller"))
        {
            puedeReparar=true;
        }
    }
    void OnTriggerExit(Collider other){
        if (other.CompareTag("Taller"))
        {
            puedeReparar = false;
        }
    }

    void RepararCommand(){
        if(puedeReparar){
            ScriptGameManager.instance.SumarPuntosV(valorSumaAmbulancia);
            puedeReparar = false;
            Destroy(areaTaller);
        }
    }
    
}
