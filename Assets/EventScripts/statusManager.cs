/*
目次
    Ⅰ.外部処理インポート
    Ⅱ.社員ステータス関連
    Ⅲ.プレイヤーステータス関連
    Ⅳ.リザルトステータス関連
    Ⅴ.Start処理
    Ⅵ.Update処理
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
        float rewardScore;
        int hitPoint;
        float remainMental;
        float baseMentalDamage;
        bool isEscaping;
        bool isEscapeSucceeded;
        public employeeStatus(int newID, float newStrength)
        {
            ID = newID;
            strength = newStrength;
            rewardScore = strength;
            hitPoint = (int)strength;
            remainMental = strength;
            baseMentalDamage = Random.Range(0.4f,4f)*5;
            isEscaping = false;
            isEscapeSucceeded = false;
        }
        public void resetStatus(float newStrength)
        {
            strength = newStrength;
            rewardScore = strength;
            hitPoint = (int)strength;
            remainMental = strength;
            baseMentalDamage = Random.Range(5f,25f);
            isEscaping = false;
        }
        public bool status_decreaceHitPoint(int damagePoint)
        {
            hitPoint -= damagePoint;
            resultStatusInstance.addTotalDamage(damagePoint);
            if (ID != 0 && hitPoint <= 0)
            {
                resetStatus(strength);
                return true;
            }
            else { return false; }
        }
        public float scoreIncreace()
        {
            return rewardScore;
        }
        public void forDebug_showAllStatus()
        {
            print(ID);
            print(strength);
            print(rewardScore);
            print(hitPoint);
        }
        public void callEscape(bool isDefine,float mentalDamageMagnification)
        {
            if(isDefine==true)
            {
                isEscaping = true;
            }
            else
            {
                remainMental -= baseMentalDamage * mentalDamageMagnification * Time.deltaTime;
                if(remainMental <= 0)
                {
                    isEscaping = true;
                    print("nowEscaped "+ID);
                }
            }
        }
        public bool checkEscaping()
        {
            return isEscaping;
        }
        public void escapeSucceed()
        {
            isEscapeSucceeded = true;
            resultStatusInstance.addSucceedEscapeNumber();
        }
    }

    public employeeStatus[] employeeStatusDataList;
    public void setupEmployeeStatus(int a)///aは登場する全社員の人数
    {
        employeeStatusDataList = new employeeStatus[a + 1];///0番目は空データにしたので1つ多め。

        for (int employeeNumber = 1; employeeNumber <= a; employeeNumber++)
        {
            employeeStatusDataList[employeeNumber] = new employeeStatus(employeeNumber, 100f);
        }

    }
    public void callAllEscape(int a)///aは登場する全社員の人数
    {
        for (int employeeNumber = 1; employeeNumber <= a; employeeNumber++)
        {
            if(employeeStatusDataList[employeeNumber].checkEscaping()==false)
            {
                employeeStatusDataList[employeeNumber].callEscape(false,1);
            }
        }
    }
    public void forDebug_showAllEmployeeStatus(int a)///aは登場する全社員の人数
    {
        for (int employeeNumber = 1; employeeNumber <= a; employeeNumber++)
        {
            print(employeeNumber);
            employeeStatusDataList[employeeNumber].forDebug_showAllStatus();
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
            int totalDamageGenerated;
            public keyAttack(int newRemainingShots, float newCooltimeSecond, int newDamage, float newAdvancedParameters)
            {
                isComboAvailable = true;
                remainingShots = newRemainingShots;
                alreadyUsedShot = 0;
                cooltimeSecond = newCooltimeSecond * 60 * Time.deltaTime;
                damage = newDamage;
                advancedParameters = newAdvancedParameters;
                totalDamageGenerated = 0;
            }
            public keyAttack(int newRemainingShots, float newCooltimeSecond, int newDamage)
            {
                isComboAvailable = true;
                remainingShots = newRemainingShots;
                alreadyUsedShot = 0;
                cooltimeSecond = newCooltimeSecond * 60;
                damage = newDamage;
                totalDamageGenerated = 0;
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
                {"通常攻撃",new keyAttack(1,0.2f,1,0)},
                {"横一列",new keyAttack(5,10f,5)},
                {"四角",new keyAttack(3,15f,20)},
                {"縦壁",new keyAttack(1,15f,0,10)}
            };
        }
    }
    
    public static playerStatus playerStatusInstance;

    //　Ⅳ.リザルトステータス関連

    public class resultStatus
    {
        public float currentScore;
        private int currentEmployeeNumber;
        private int currentPreventEscapeNumber;//こっちが脱走阻止回数
        private int currentSucceedEscapeNumber;//こっちが脱走成功回数
        private int currentTotalDamage;
        public resultStatus()
        {
            currentScore = 0;
            currentEmployeeNumber = 4;
            currentPreventEscapeNumber = 0;
            currentSucceedEscapeNumber = 0;
            currentTotalDamage = 0;
        }
        public void addPreventEscapeNumber(){currentPreventEscapeNumber++;}
        public void addSucceedEscapeNumber(){currentSucceedEscapeNumber++;}
        public void justNowDestroyed(float rewardScore)
        {
            addPreventEscapeNumber();
            currentScore += rewardScore;
            print("score is now " + currentScore + " points !");
        }
        public void addTotalDamage(int damage)
        {
            currentTotalDamage += damage;
        }
        public class endgameResultStatus
        {
            public float endgameScore{get; private set;}
            public int endgameEmployeeNumber{get; private set;}
            public int endgamePreventEscapeNumber{get; private set;}
            public int endgameSucceedEscapeNumber{get; private set;}
            public int endgameTotalDamage{get; private set;}
            public endgameResultStatus(float a,int b,int c,int d,int e)
            {
                endgameScore = a;
                endgameEmployeeNumber = b;
                endgamePreventEscapeNumber = c;
                endgameSucceedEscapeNumber = d;
                endgameTotalDamage = e;
            }
        }
        public endgameResultStatus createEndgameResultStatus()
        {
            return new endgameResultStatus
            (
                this.currentScore,
                this.currentEmployeeNumber,
                this.currentPreventEscapeNumber,
                this.currentSucceedEscapeNumber,
                this.currentTotalDamage
            );
        }
    }
    public static resultStatus resultStatusInstance = new resultStatus();

    //　Ⅴ.Start処理

    int employeeAmount = 12;
    void Start()
    {
        setupEmployeeStatus(employeeAmount);
        playerStatusInstance = new playerStatus();
        playerStatusInstance.setupKeyAttack();
    }

    //　Ⅵ.Update処理

    void Update()
    {
        callAllEscape(employeeAmount);
    }
}