using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreUI;
    public void drawResultCanvas()
    {
        var statusManager = GameObject.FindObjectOfType<statusManager>();
        statusManager.resultStatus.endgameResultStatus result = statusManager.resultStatusInstance.createEndgameResultStatus();

        print("スコア："+result.endgameScore);
        print("社員数："+result.endgameEmployeeNumber);
        print("脱走阻止数："+result.endgamePreventEscapeNumber);
        print("脱走成功数："+result.endgameSucceedEscapeNumber);
        print("総ダメージ量："+result.endgameTotalDamage);
        
        GameObject inGameCanvas = GameObject.Find("inGameCanvas");
        var componentInGameCanvas = inGameCanvas.GetComponent<Canvas>();
        componentInGameCanvas.enabled = false;

        print(inGameCanvas);

        GameObject resultCanvas = GameObject.Find("resultCanvas");
        var componentResultCanvas = resultCanvas.GetComponent<Canvas>();
        componentResultCanvas.enabled = true;
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