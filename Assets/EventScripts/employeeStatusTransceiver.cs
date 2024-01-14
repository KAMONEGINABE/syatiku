using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class employeeStatusTransceiver : MonoBehaviour
{
    [SerializeField]private int employeeNumber;
    public bool justNowHit;
    public bool destroyed;
    bool lastEscapingState = false;
    GameObject scriptManager;
    
    public void hitCalculation(int damage)
    {
        scriptManager = GameObject.Find("scriptManager");
        statusManager statusManager = scriptManager.GetComponent<statusManager>();
        
        justNowHit = true;
        destroyed = statusManager.employeeStatusDataList[employeeNumber].status_decreaceHitPoint(damage);//ついでに向こうで勝手に撃破を検知して、適切なステータス処理をしてくれる
        if(destroyed)
        {
            statusManager.resultStatusInstance.justNowDestroyed(statusManager.employeeStatusDataList[employeeNumber].scoreIncreace());
            //デバッグ用：Destroy(gameObject,0.02f);
        }
    }

    void Update()
    {
        scriptManager = GameObject.Find("scriptManager");
        statusManager statusManager = scriptManager.GetComponent<statusManager>();

        if(statusManager.employeeStatusDataList[employeeNumber].checkEscaping() != lastEscapingState)
        {
            lastEscapingState = statusManager.employeeStatusDataList[employeeNumber].checkEscaping();
            print("スイッチ起動");
            CustomEvent.Trigger(this.gameObject,"setRendererEnable",lastEscapingState);
        }
        
        if(this.gameObject.transform.position.x >= 7)
        {
            statusManager.employeeStatusDataList[employeeNumber].escapeSucceed();
            this.enabled = false;
        }
    }
}
