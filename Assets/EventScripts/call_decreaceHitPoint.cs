using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call_decreaceHitPoint : MonoBehaviour
{
    [Header("攻撃タイプ（ 通常攻撃 or 横一列 or 四角 or 縦壁 ）")][SerializeField]private string attackType;
    [Header("【デバッグ用】ダメージ倍率")][SerializeField]private int damageMultiplier = 1;
    GameObject scriptManager;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        scriptManager = GameObject.Find("scriptManager");
        statusManager statusManager = scriptManager.GetComponent<statusManager>();

        employeeStatusTransceiver employeeStatusTransceiver = other.GetComponent<employeeStatusTransceiver>();
        if(employeeStatusTransceiver != null)
        {
            int damage = statusManager.playerStatusInstance.keyAttackList[attackType].damage * damageMultiplier;
            employeeStatusTransceiver.hitCalculation(damage);
        }
    }
}