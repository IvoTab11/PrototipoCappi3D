using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;  

public class MainPanel : MonoBehaviour
{
     [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelSelectPanel;

    public void PlayLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }
    public void SetMute(){
       
        if(mute.isOn){
          mixer.GetFloat("VOLMASTER", out lastVolume);
          mixer.SetFloat("VOLMASTER", -80);
        }
        
        else
        mixer.SetFloat("VOLMASTER", lastVolume);
    }

    public void ExitGame(){
        Application.Quit();
    }

    private void Awake(){
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);

    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    public void ChangeVolumeMaster(float v){
        mixer.SetFloat("VOLMASTER", v);
    }
    public void ChangeVolumeFX(float v){
        mixer.SetFloat("volFX", v);
    }

    public void PlaySoundButton(){
        fxSource.PlayOneShot(clickSound);
    }
}
