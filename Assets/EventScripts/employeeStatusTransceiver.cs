using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class employeeStatusTransceiver : MonoBehaviour
{
    [SerializeField]private int employeeNumber;
    [HideInInspector]public int EmployeeNumber;
    public bool justNowHit;
    public bool destroyed;
    bool lastEscapingState = false;
    GameObject scriptManager;
    statusManager statusManager;
    escapeRouteRunner escapeRouteRunner;
    int textureType;
    Animator animator;
    
    public void hitCalculation(int damage)
    {
        scriptManager = GameObject.Find("scriptManager");
        statusManager = scriptManager.GetComponent<statusManager>();
        
        justNowHit = true;
        destroyed = statusManager.employeeStatusDataList[employeeNumber].status_decreaceHitPoint(damage);
        if(destroyed)
        {
            statusManager.resultStatusInstance.justNowDestroyed(statusManager.employeeStatusDataList[employeeNumber].scoreIncreace());
            escapeRouteRunner.returnDesk();
        }
    }

    void Start()
    {
        EmployeeNumber = employeeNumber;
        scriptManager = GameObject.Find("scriptManager");
        statusManager = scriptManager.GetComponent<statusManager>();
        animator = GetComponent<Animator>();
        escapeRouteRunner = GetComponent<escapeRouteRunner>();
    }

    void Update()
    {
        if(statusManager.employeeStatusDataList[employeeNumber].checkEscaping() != lastEscapingState)
        {
            lastEscapingState = statusManager.employeeStatusDataList[employeeNumber].checkEscaping();
            CustomEvent.Trigger(this.gameObject,"setEmployeeRenderer",lastEscapingState);
        }
        
        if(this.gameObject.transform.position.x >= 7)
        {
            statusManager.employeeStatusDataList[employeeNumber].escapeSucceed();
            this.enabled = false;
        }

        textureType = statusManager.employeeStatusDataList[employeeNumber].textureType;
        animator.SetInteger("textureType",textureType);
    }
}
