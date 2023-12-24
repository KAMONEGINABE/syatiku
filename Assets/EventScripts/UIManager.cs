using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreUI;
    public void drawResultCanvas()
    {
        statusManager.resultStatus.endgameResultStatus result = statusManager.resultStatusInstance.createEndgameResultStatus();
        
        
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        var statusManager = GameObject.FindObjectOfType<statusManager>();
        scoreUI.text = statusManager.resultStatusInstance.currentScore.ToString();
    }
}