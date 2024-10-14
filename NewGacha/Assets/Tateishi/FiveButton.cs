using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class FiveButton : MonoBehaviour
{
    static int point = 0;   //合計ポイント
    static int atari;

    public void OnClickEvent()
    {
        Debug.Log("5連ガチャのボタンを押しました");
        SceneManager.LoadScene("FiveDemo");
        fivegacha();
    }

    public static void fivegacha()   //５連ガチャ
    {
        int[] array1 = new int[5];
        for (int i = 0; i <= 3; i++)
        {
            probability();
            array1[i] = atari;  //配列に当たりの番号を格納

            if (array1[i] == 0) //当たりの番号に応じて演出開始andポイント加算
            {
                Debug.Log("演出なし");
            }
            else if (array1[i] == 1)
            {
                Debug.Log("点滅開始");
                BlinkRed1.isStart = true;
            }
            else if (array1[i] == 2)
            {
                Debug.Log("振動開始");
                ShakeObject1.isShake = true;
            }
            else if (array1[i] == 3)
            {
                Debug.Log("演出3開始");
            }
        }

        ShakeObject1.isShake = true;    //確定枠の演出の開始
        point += 20;
        Debug.Log("確定演出");

        Debug.Log("合計" + point + "ポイント獲得!");
    }

    public static void probability()  //排出率
    {
        int a = Random.Range(1, 1000);

        if (a <= 800)
        {
            atari = 0;
            point += 1;
            Debug.Log("1ポイントゲット! 現在" + point + "ポイント");
        }
        else if (a <= 990)
        {
            atari = 1;
            point += 5;
            Debug.Log("5ポイントゲット! 現在" + point + "ポイント");
        }
        else if (a <= 999)
        {
            atari = 2;
            point += 20;
            Debug.Log("20ポイントゲット! 現在" + point + "ポイント");
        }
        else
        {
            atari = 3;
            point += 50;
            Debug.Log("50ポイントゲット! 現在" + point + "ポイント");
        }
    }
}
