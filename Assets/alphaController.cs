using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class alphaController : MonoBehaviour
{
    float maxTimer;
    float currentTimer;
    bool isAlphaStrong;
    void Awake()
    {
        CustomEvent.Trigger(this.gameObject,"setAlpha",100f);
        maxTimer = 0.5f;
        currentTimer = 0f;
        isAlphaStrong = true;
    }

    void Update()
    {
        currentTimer += Time.deltaTime;
        if(maxTimer <= currentTimer)
        {
            isAlphaStrong = !isAlphaStrong;
        }

        if(isAlphaStrong)
        {
            CustomEvent.Trigger(this.gameObject,"setAlpha",100f);
        }
        else
        {
            CustomEvent.Trigger(this.gameObject,"setAlpha",50f);
        }
        
    }
}
