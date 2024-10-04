using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;
public class Bar : MonoBehaviour
{
    public GameObject bar;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateBar(){
        LeanTween.scaleX(bar, 1, time).setOnComplete(OnBarFull);
        // if(time<=1){
        //     SceneManager.LoadScene("Game Over");
        // }
    }
    void OnBarFull()
    {
        // Cambiar a la nueva escena cuando la animación termine
        SceneManager.LoadScene("Game Over");
    }
}
