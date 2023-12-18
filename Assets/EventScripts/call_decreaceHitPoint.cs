using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call_decreaceHitPoint : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        employeeStatusTransceiver employeeStatusTransceiver = other.GetComponent<employeeStatusTransceiver>();
        if(employeeStatusTransceiver != null){
            employeeStatusTransceiver.hitCalculation(1);
        }
    }

}
