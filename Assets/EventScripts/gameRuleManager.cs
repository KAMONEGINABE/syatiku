using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameRuleManager : MonoBehaviour
{

    public static class timeLimit
    {
        static float timeLimitSecond; 
        static float currentTimeSecond;
        public static void setupTimeLimit(float newTimeLimitSecond)
        {
            timeLimitSecond = newTimeLimitSecond;
            currentTimeSecond = 0;
            
        }
        public static void updateCurrentTime()
        {
            currentTimeSecond += Time.deltaTime;
        }
        public static bool isTimeLimitReached()
        {
            if(currentTimeSecond >= timeLimitSecond)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    [SerializeField]private float timeLimitSecond;

    void Start()
    {
        timeLimit.setupTimeLimit(timeLimitSecond);
    }

    void Update()
    {
        timeLimit.updateCurrentTime();
        if(timeLimit.isTimeLimitReached())
        {
            var keyInputManager = GameObject.FindObjectOfType<keyInputManager>();
            keyInputManager.enabled = false;
            
            var statusManager = GameObject.FindObjectOfType<statusManager>();
            statusManager.resultStatus.endgameResultStatus result = statusManager.resultStatusInstance.createEndgameResultStatus();
            print("ゲーム終了！");
            print("スコア："+result.endgameScore);
            print("社員数："+result.endgameEmployeeNumber);
            print("脱走阻止数："+result.endgamePreventEscapeNumber);
            print("脱走成功数："+result.endgameSucceedEscapeNumber);
            print("総ダメージ量："+result.endgameTotalDamage);

            var gameRuleManager = GameObject.FindObjectOfType<gameRuleManager>();
            gameRuleManager.enabled = false;
        }
    }
}