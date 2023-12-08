using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public sealed class masako : MonoBehaviour
{
    //public static bool KZ;
    // public static bool ZBox;
    public static bool KZ = false;
    public static bool ZBox = false;

    public GameObject hitTrigger;

    /// <summary>
    /// 連続入力を禁止する
    /// </summary>
    public static class MyInput
    {
        static bool isCheck_Input;
        static bool preventContinuityInput;
        static float buttonDownTime;
        static float timer; // この行を追加
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


    Vector3 KeyMemory_1 = new Vector3(0.0f,0.0f,0.0f);
    Vector3 KeyMemory_2 = new Vector3(0.0f,0.0f,0.0f);
    Vector3 KeyMemory_3 = new Vector3(0.0f,0.0f,0.0f);



    void Update()
    {
        if (MyInput.MyInputKeyDown(KeyCode.Z))
        {
            print("Z");
            KZ = true;
            ZBox = true;
            Update_KeyMemory(-6.7f,0.5f,-1.9f);
            Debug.Log("koko");
        }
        if (MyInput.MyInputKeyDown(KeyCode.X))
        {
            print("X");
            Instantiate(hitTrigger,new Vector3(-5.4f,0.5f,-1.9f),Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.C))
        {
            print("C");
            Instantiate(hitTrigger,new Vector3(-4.1f,0.5f,-1.9f),Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.V))
        {
            print("V");
            Instantiate(hitTrigger,new Vector3(-2.8f,0.5f,-1.9f),Quaternion.identity);
        }
        if (MyInput.MyInputKeyDown(KeyCode.B))
        {
            print("B");
            Instantiate(hitTrigger,new Vector3(-1.5f,0.5f,-1.9f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.N))
        {
            print("N");
            Instantiate(hitTrigger,new Vector3(-0.2f,0.5f,-1.9f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.M))
        {
            print("M");
            Instantiate(hitTrigger,new Vector3(1.1f,0.5f,-1.9f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.A))
        {
            print("A");
            Instantiate(hitTrigger,new Vector3(-7.3f,0.5f,-0.87f),Quaternion.identity);

        }
         if (MyInput.MyInputKeyDown(KeyCode.S))
        {
            print("S");
            Instantiate(hitTrigger,new Vector3(-6.04f,0.5f,-0.87f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.D))
        {
            print("D");
            Instantiate(hitTrigger,new Vector3(-4.78f,0.5f,-0.87f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.F))
        {
            print("F");
            Instantiate(hitTrigger,new Vector3(-3.52f,0.5f,-0.87f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.G))
        {
            print("G");
            Instantiate(hitTrigger,new Vector3(-2.26f,0.5f,-0.87f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.H))
        {
            print("H");
            Instantiate(hitTrigger,new Vector3(-1f,0.5f,-0.87f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.J))
        {
            print("J");
            Instantiate(hitTrigger,new Vector3(0.26f,0.5f,-0.87f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.K))
        {
            print("K");
            Instantiate(hitTrigger,new Vector3(1.52f,0.5f,-0.87f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.L))
        {
            print("L");
            Instantiate(hitTrigger,new Vector3(2.78f,0.5f,-0.87f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Q))
        {
            print("Q");
            Instantiate(hitTrigger,new Vector3(-7.95f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.W))
        {
            print("W");
            Instantiate(hitTrigger,new Vector3(-6.68f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.E))
        {
            print("E");
            Instantiate(hitTrigger,new Vector3(-5.41f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.R))
        {
            print("R");
            Instantiate(hitTrigger,new Vector3(-4.14f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.T))
        {
            print("T");
            Instantiate(hitTrigger,new Vector3(-2.87f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Y))
        {
            print("Y");
            Instantiate(hitTrigger,new Vector3(-1.6f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.U))
        {
            print("U");
            Instantiate(hitTrigger,new Vector3(-0.33f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.I))
        {
            print("I");
            Instantiate(hitTrigger,new Vector3(0.94f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.O))
        {
            print("O");
            Instantiate(hitTrigger,new Vector3(2.21f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.P))
        {
            print("P");
            Instantiate(hitTrigger,new Vector3(3.48f,0.5f,0.16f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha1))
        {
            print("1");
            Instantiate(hitTrigger,new Vector3(-8.5f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha2))
        {
            print("2");
            Instantiate(hitTrigger,new Vector3(-7.25f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha3))
        {
            print("3");
            Instantiate(hitTrigger,new Vector3(-6f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha4))
        {
            print("4");
            Instantiate(hitTrigger,new Vector3(-4.75f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha5))
        {
            print("5");
            Instantiate(hitTrigger,new Vector3(-3.5f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha6))
        {
            print("6");
            Instantiate(hitTrigger,new Vector3(-2.25f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha7))
        {
            print("7");
            Instantiate(hitTrigger,new Vector3(-1f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha8))
        {
            print("8");
            Instantiate(hitTrigger,new Vector3(0.25f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha9))
        {
            print("9");
            Instantiate(hitTrigger,new Vector3(1.5f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha0))
        {
            print("0");
            Instantiate(hitTrigger,new Vector3(2.75f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Minus))
        {
            print("-");
            Instantiate(hitTrigger,new Vector3(4f,0.5f,1.25f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Caret))
        {
            print("^");
            Instantiate(hitTrigger,new Vector3(5.25f,0.5f,1.25f),Quaternion.identity);
        }

         if (MyInput.MyInputKeyDown(KeyCode.Semicolon))
        {
            print(";");
            Instantiate(hitTrigger,new Vector3(4.04f,0.5f,-0.87f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Colon))
        {
            print(":");
            Instantiate(hitTrigger,new Vector3(5.3f,0.5f,-0.87f),Quaternion.identity);
        }

         if (MyInput.MyInputKeyDown(KeyCode.At))
        {
            print("@");
            Instantiate(hitTrigger,new Vector3(4.75f,0.5f,0.16f),Quaternion.identity);
        }

         if (MyInput.MyInputKeyDown(KeyCode.Comma))
        {
            print(",");
            Instantiate(hitTrigger,new Vector3(2.4f,0.5f,-1.9f),Quaternion.identity);
        }
         if (MyInput.MyInputKeyDown(KeyCode.Period))
        {
            print(".");
            Instantiate(hitTrigger,new Vector3(3.7f,0.5f,-1.9f),Quaternion.identity);
        }

         if (MyInput.MyInputKeyDown(KeyCode.Slash))
        {
            print("/");
            Instantiate(hitTrigger,new Vector3(5f,0.5f,-1.9f),Quaternion.identity);
        }
        //trueじゃなければHPマイナス
        if (MyInput.MyInputKeydown(KeyCode.Space, 1 / 2))
        {
            print("3秒待つと押せるよ");
        }
    }
}
