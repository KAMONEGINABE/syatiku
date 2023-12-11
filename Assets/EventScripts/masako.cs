using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public sealed class masako : MonoBehaviour
{
    //public static bool KZ;
    // public static bool ZBox;

    public GameObject hitTrigger;

    /// <summary>googogogog
    /// 連続入力を禁止する
    /// </summary>
    public static class MyInput
    {
        static bool isCheck_Input;
        static bool preventContinuityInput;

        static float buttonDownTime;
        static float timer;



        /// <summary>
        /// Simultaneous input prohibited
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool MyInputKeyDown(KeyCode key)
        {
            if (Input.anyKeyDown == false) isCheck_Input = false;

            if (isCheck_Input == false)
            {
                if (Input.GetKeyDown(key))
                {
                    isCheck_Input = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Continuity input prohibited
        /// </summary>
        /// <param name="key"></param>
        /// <param name="intervalSeconds"></param>
        /// <returns></returns>
        public static bool MyInputKeydown(KeyCode key, float intervalSeconds)
        {
            timer = Time.time;

            if (Input.GetKeyDown(key) && timer - buttonDownTime >= intervalSeconds)
            {
                if (preventContinuityInput == false)
                {
                    preventContinuityInput = true;
                    buttonDownTime = Time.time;
                    return true;
                }
                else if (preventContinuityInput)
                {
                    preventContinuityInput = false;
                    buttonDownTime = Time.time;
                    return true;
                }
            }

            return false;
        }
    }

    Vector3 KeyMemory_1 = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 KeyMemory_2 = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 KeyMemory_3 = new Vector3(0.0f, 0.0f, 0.0f);


    float value_1 = KeyMemory_1.x - KeyMemory_2.x;
    float absoluteValue_1 = Mathf.Abs(value_1);
    float value_2 = KeyMemory_2.x - KeyMemory_3.x;
    float absoluteValue_2 = Mathf.Abs(value_2);


    
    void Update()
    {
        void Update_KeyMemory(Vector3 NewKeyVector3)
    {
        KeyMemory_3 = KeyMemory_2;
        KeyMemory_2 = KeyMemory_1;
        KeyMemory_1 = NewKeyVector3;
        print(KeyMemory_1);
    }
        if (MyInput.MyInputKeyDown(KeyCode.Z))
        {
            print("Z");
            Update_KeyMemory(new Vector3(-6.7f, 0.5f, -1.7f));
            Instantiate(hitTrigger, KeyMemory_1, Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.X))
        {
            print("X");
            Update_KeyMemory(new Vector3(-5.4f, 0.5f, -1.7f));
            Instantiate(hitTrigger, KeyMemory_1, Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.C))
        {
            print("C");
            Update_KeyMemory(new Vector3(-4.1f, 0.5f, -1.7f));
            Instantiate(hitTrigger, new Vector3(-4.1f, 0.5f, -1.7f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.V))
        {
            print("V");
            Update_KeyMemory(new Vector3(-2.8f, 0.5f, -1.7f));
            Instantiate(hitTrigger, new Vector3(-2.8f, 0.5f, -1.7f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.B))
        {
            print("B");
            Update_KeyMemory(new Vector3(-1.5f, 0.5f, -1.7f));
            Instantiate(hitTrigger, new Vector3(-1.5f, 0.5f, -1.7f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.N))
        {
            print("N");
            Update_KeyMemory(new Vector3(-0.2f, 0.5f, -1.7f));
            Instantiate(hitTrigger, new Vector3(-0.2f, 0.5f, -1.7f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.M))
        {
            print("M");
            Update_KeyMemory(new Vector3(1.1f, 0.5f, -1.7f));
            Instantiate(hitTrigger, new Vector3(1.1f, 0.5f, -1.7f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.A))
        {
            print("A");
            Update_KeyMemory(new Vector3(-7.3f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(-7.3f, 0.5f, -0.67f), Quaternion.identity);

        }
        if (MyInput.MyInputKeyDown(KeyCode.S))
        {
            print("S");
            Update_KeyMemory(new Vector3(-6.04f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(-6.04f, 0.5f, -0.67f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.D))
        {
            print("D");
            Update_KeyMemory(new Vector3(-4.78f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(-4.78f, 0.5f, -0.67f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.F))
        {
            print("F");
            Update_KeyMemory(new Vector3(-3.52f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(-3.52f, 0.5f, -0.67f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.G))
        {
            print("G");
            Update_KeyMemory(new Vector3(-2.26f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(-2.26f, 0.5f, -0.67f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.H))
        {
            print("H");
            Update_KeyMemory(new Vector3(-1f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(-1f, 0.5f, -0.67f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.J))
        {
            print("J");
            Update_KeyMemory(new Vector3(0.26f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(0.26f, 0.5f, -0.67f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.K))
        {
            print("K");
            Update_KeyMemory(new Vector3(1.52f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(1.52f, 0.5f, -0.67f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.L))
        {
            print("L");
            Update_KeyMemory(new Vector3(2.78f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(2.78f, 0.5f, -0.67f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Q))
        {
            print("Q");
            Update_KeyMemory(new Vector3(-7.95f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(-7.95f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.W))
        {
            print("W");
            Update_KeyMemory(new Vector3(-6.68f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(-6.68f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.E))
        {
            print("E");
            Update_KeyMemory(new Vector3(-5.41f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(-5.41f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.R))
        {
            print("R");
            Update_KeyMemory(new Vector3(-4.14f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(-4.14f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.T))
        {
            print("T");
            Update_KeyMemory(new Vector3(-2.87f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(-2.87f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Y))
        {
            print("Y");
            Update_KeyMemory(new Vector3(-1.6f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(-1.6f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.U))
        {
            print("U");
            Update_KeyMemory(new Vector3(-0.33f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(-0.33f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.I))
        {
            print("I");
            Update_KeyMemory(new Vector3(0.94f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(0.94f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.O))
        {
            print("O");
            Update_KeyMemory(new Vector3(2.21f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(2.21f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.P))
        {
            print("P");
            Update_KeyMemory(new Vector3(3.48f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(3.48f, 0.5f, 0.36f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha1))
        {
            print("1");
            Update_KeyMemory(new Vector3(-8.5f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(-8.5f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha2))
        {
            print("2");
            Update_KeyMemory(new Vector3(-7.25f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(-7.25f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha3))
        {
            print("3");
            Update_KeyMemory(new Vector3(-6f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(-6f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha4))
        {
            print("4");
            Update_KeyMemory(new Vector3(-4.75f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(-4.75f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha5))
        {
            print("5");
            Update_KeyMemory(new Vector3(-3.5f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(-3.5f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha6))
        {
            print("6");
            Update_KeyMemory(new Vector3(-2.25f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(-2.25f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha7))
        {
            print("7");
            Update_KeyMemory(new Vector3(-1f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(-1f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha8))
        {
            print("8");
            Update_KeyMemory(new Vector3(0.25f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(0.25f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha9))
        {
            print("9");
            Update_KeyMemory(new Vector3(1.5f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(1.5f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Alpha0))
        {
            print("0");
            Update_KeyMemory(new Vector3(2.75f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(2.75f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Minus))
        {
            print("-");
            Update_KeyMemory(new Vector3(4f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(4f, 0.5f, 1.45f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Caret))
        {
            print("^");
            Update_KeyMemory(new Vector3(5.25f, 0.5f, 1.45f));
            Instantiate(hitTrigger, new Vector3(5.25f, 0.5f, 1.45f), Quaternion.identity);
        }

        if (MyInput.MyInputKeyDown(KeyCode.Semicolon))
        {
            print(";");
            Update_KeyMemory(new Vector3(4.04f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(4.04f, 0.5f, -0.67f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Colon))
        {
            print(":");
            Update_KeyMemory(new Vector3(5.3f, 0.5f, -0.67f));
            Instantiate(hitTrigger, new Vector3(5.3f, 0.5f, -0.67f), Quaternion.identity);
        }

        if (MyInput.MyInputKeyDown(KeyCode.At))
        {
            print("@");
            Update_KeyMemory(new Vector3(4.75f, 0.5f, 0.36f));
            Instantiate(hitTrigger, new Vector3(4.75f, 0.5f, 0.36f), Quaternion.identity);
        }

        if (MyInput.MyInputKeyDown(KeyCode.Comma))
        {
            print(",");
            Update_KeyMemory(new Vector3(2.4f, 0.5f, -1.7f));
            Instantiate(hitTrigger, new Vector3(2.4f, 0.5f, -1.7f), Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.Period))
        {
            print(".");
            Update_KeyMemory(new Vector3(3.7f, 0.5f, -1.7f));
            Instantiate(hitTrigger, new Vector3(3.7f, 0.5f, -1.7f), Quaternion.identity);
        }

        if (MyInput.MyInputKeyDown(KeyCode.Slash))
        {
            print("/");
            Update_KeyMemory(new Vector3(5f, 0.5f, -1.7f));
            Instantiate(hitTrigger, new Vector3(5f, 0.5f, -1.7f), Quaternion.identity);
        }
        if (KeyMemory_1.x  == KeyMemory_2.x == KeyMemory_3.x > 0f && absoluteValue_1 < 1.5f && absoluteValue_2 < 1.5f)
        {



            KeyMemory_1.x = 0;
            KeyMemory_2.x = 0;
            KeyMemory_3.x = 0;
        }
        if (MyInput.MyInputKeydown(KeyCode.Space, 1 / 2))
        {
            print("3秒待つと押せるよ");
        }
    }



}
