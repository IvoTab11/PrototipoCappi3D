using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech; // Necesario para usar KeywordRecognizer
using System.Linq;

public class GameOver : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    void Start(){
        keywords.Add("Reiniciar", () => { ReiniciarCommand(); });

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
    public void PlayAgain(){
        SceneManager.LoadScene("Level01");   
        Debug.Log("nivel uan");
    }

     public void MainMenu(){
        SceneManager.LoadScene("MainMenu");   
        Debug.Log("menu principal");
    }
    void ReiniciarCommand(){
        SceneManager.LoadScene("Level1");
    }
}