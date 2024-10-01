using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesUI : MonoBehaviour
{
    [SerializeField] private GameObject logo;

    private void Start(){
        LeanTween.moveX(logo.GetComponent<RectTransform>(), 170, 1.5f).setDelay(2.5f).setEase(LeanTweenType.easeOutBounce);
    }
}
