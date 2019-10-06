using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{

    [SerializeField]
    TMP_Text tmtext;
    [SerializeField]
    Color textColor;

    [SerializeField]
    private float fadeTime = 2.0f;
    [SerializeField]
    private float lerpAmount = 0f;
    [SerializeField]
    private float lerpCount = 0f;



    private bool fadeIn = false;

    public void Update()
    {
        if (fadeIn)
        {
            //fade in the text
            tmtext.color = Color.Lerp(Color.clear, textColor, lerpAmount);
            lerpCount += Time.deltaTime;
            if (lerpCount >= fadeTime) lerpCount = fadeTime;

        }
        else
        {
            tmtext.color = Color.Lerp(Color.clear, textColor, lerpAmount);
            lerpCount -= Time.deltaTime;
            if (lerpCount <= 0) lerpCount = 0f;

        }
        lerpAmount = lerpCount / fadeTime;
    }


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.name + " Tag: " + other.tag);
        if (other.CompareTag("Player"))
        {
            fadeIn = true;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit: " + other.name + " Tag: " + other.tag);
        if (other.CompareTag("Player"))
        {
            fadeIn = false;

        }

    }

}
