using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthFluidGUI : MonoBehaviour
{
    [SerializeField]
    private Image fluidFillImage;

    [SerializeField]
    private float lerpTime = 0.5f;
    private float lerpChange = 0f;
    [SerializeField]
    private playerHealth playerHP;
    [SerializeField]
    private float targetFill;
    void Awake()
    {
        playerHP = PlayerManager.instance.player.GetComponent<playerHealth>();
        fluidFillImage = GetComponent<Image>();
    }

    void Update()
    {
        targetFill = PlayerManager.instance.player.GetComponent<hp>().getHealthPercent();
        Debug.Log("health percent: " + targetFill);
        fluidFillImage.fillAmount = playerHP.getHealthPercent();             
    }
}
