using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; 
using UnityEngine;

public class deskStatusTrans : MonoBehaviour
{
    [SerializeField]private int employeeNumber;
    bool lastEscapingState = false;
    GameObject scriptManager;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        scriptManager = GameObject.Find("scriptManager");
        statusManager statusManager = scriptManager.GetComponent<statusManager>();
        
        if(lastEscapingState != statusManager.employeeStatusDataList[employeeNumber].checkEscaping())
        {
            lastEscapingState = statusManager.employeeStatusDataList[employeeNumber].checkEscaping();
            CustomEvent.Trigger(this.gameObject,"setDeskRenderer",lastEscapingState);
            print("switch");
        }

        animator.SetInteger("textureType",statusManager.employeeStatusDataList[employeeNumber].textureType);
        animator.SetBool("isEscaping",lastEscapingState);
    }
}
