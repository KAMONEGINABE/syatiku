/*
目次
    Ⅰ.外部処理インポート
    Ⅱ.社員ステータス関連
    Ⅲ.プレイヤーステータス関連
    Ⅳ.起動時セットアップ
*/

// Ⅰ.外部処理インポート

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusManager : MonoBehaviour
{
    // Ⅱ.社員ステータス関連
    public class employeeStatus     //社員データとそれを使った関数を全部格納した型
    {
        int ID;
        float strength;
        float scoreIncreace;
        int hitPoint;

        public employeeStatus(int newID, float newStrength)
        {
            ID = newID;
            strength = newStrength;
            scoreIncreace = strength;
            hitPoint = (int)strength;
        }
        public void status_setAgain(float newStrength)
        {
            strength = newStrength;
            scoreIncreace = strength;
            hitPoint = (int)strength;
        }
        public bool status_decreaceHitPoint(int damagePoint)
        {
            hitPoint -= damagePoint;
            if (ID != 0 && hitPoint <= 0)
            {
                status_setAgain(strength);
                return true;
            }
            else { return false; }
        }
        public void forDebug_showAllStatus()
        {
            print(ID);
            print(strength);
            print(scoreIncreace);
            print(hitPoint);
        }
    }

    public employeeStatus[] StatusDataList;
    public void setupEmployeeStatus(int a)///aは登場する全社員の人数
    {
        StatusDataList = new employeeStatus[a + 1];///0番目は空データにしたので1つ多め。

        for (int employeeNumber = 1; employeeNumber <= a; employeeNumber++)
        {
            StatusDataList[employeeNumber] = new employeeStatus(employeeNumber, 100f);
        }

    }
    public void forDebug_showAllEmployeeStatus(int a)///aは登場する全社員の人数
    {
        for (int employeeNumber = 1; employeeNumber <= a; employeeNumber++)
        {
            print(employeeNumber);
            StatusDataList[employeeNumber].forDebug_showAllStatus();
        }
    }

    // Ⅲ.プレイヤーステータス関連

    public class playerStatus
    {
        public class keyAttack
        {
            public bool isComboAvailable{ get; private set;}
            int remainingShots;
            int alreadyUsedShot;
            float cooltimeSecond;
            public int damage{ get; }
            float advancedParameters;
            public keyAttack(int newRemainingShots, float newCooltimeSecond, int newDamage, float newAdvancedParameters)
            {
                isComboAvailable = true;
                remainingShots = newRemainingShots;
                alreadyUsedShot = 0;
                cooltimeSecond = newCooltimeSecond * 60 * Time.deltaTime;
                damage = newDamage;
                advancedParameters = newAdvancedParameters;
            }
            public keyAttack(int newRemainingShots, int newCooltimeSecond, int newDamage)
            {
                isComboAvailable = true;
                remainingShots = newRemainingShots;
                alreadyUsedShot = 0;
                cooltimeSecond = newCooltimeSecond * 60;
                damage = newDamage;
            }
            public void consumeRemainingShots()
            {
                alreadyUsedShot++;
                if(remainingShots<=alreadyUsedShot){
                    alreadyUsedShot = 0;
                    startCooltime();
                }
            }
            public IEnumerator startCooltime()
            {
                isComboAvailable = false;
                yield return new WaitForSeconds(cooltimeSecond);
                isComboAvailable = true;
            }
        }

        public Dictionary<string, keyAttack> keyAttackList;
        public void setupKeyAttack()
        {
            keyAttackList = new Dictionary<string, keyAttack>()
            {
                {"通常攻撃",new keyAttack(1,0,1,0)},
                {"横一列",new keyAttack(5,10,5)},
                {"四角",new keyAttack(3,15,20)},
                {"縦壁",new keyAttack(1,15,0,10)}
            };
        }
    }

    public playerStatus playerStatusInstance;

    //　Ⅳ.ゲーム起動時処理
    void Start()
    {
        setupEmployeeStatus(12);
        playerStatusInstance = new playerStatus();
        playerStatusInstance.setupKeyAttack();
    }
}