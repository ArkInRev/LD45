using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager>
{

    public GameObject player;


    [SerializeField]
    private Image fluidFillImage;

    [SerializeField]
    private float lerpTime = 0.5f;
    private float lerpChange = 0f;
    [SerializeField]
    private playerHealth playerHP;
    [SerializeField]
    private float targetFill;


    private void Awake()
    {
        instance = this;
        playerHP = player.GetComponent<playerHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetFill = player.GetComponent<hp>().getHealthPercent();
        //Debug.Log("health percent: " + targetFill);
        fluidFillImage.fillAmount = playerHP.getHealthPercent();
    }
}
