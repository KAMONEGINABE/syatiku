using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call_decreaceHitPoint : MonoBehaviour
{
    [SerializeField]private int damage = 0;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        employeeStatusTransceiver employeeStatusTransceiver = other.GetComponent<employeeStatusTransceiver>();
        if(employeeStatusTransceiver != null){
            employeeStatusTransceiver.hitCalculation(damage);
        }
    }

}
