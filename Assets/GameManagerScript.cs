using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    void PrintArray()
    {
        string debugText = "";
        for(int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    int GetPlayerIndex()
    {
        for(int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number,int moveFrom,int moveTo)
    {
        if (moveTo < 0||moveTo >= map.Length)
        {
            // 動けない条件を先に書き、リターンする。
            return false;
        }
        // 移動先に箱があったら
        if (map[moveTo] == 2)
        {
            int velocity = moveTo - moveFrom;
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            if (!success) { 
                return false; 
            }
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    // 配列の宣言
    int[] map;

    // Start is called before the first frame update
    void Start()
    {
        // 配列の実態の生成と初期化
        map = new int[] { 0, 0, 2, 1, 0, 2, 0, 0, 0 };
        // 追加。文字列の宣言と初期化
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        // 右移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // 見つからなかった時のために-1で初期化
            int playerIndex = GetPlayerIndex();
            // 要素数はmap.Lengthで取得
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }

            MoveNumber(1, playerIndex, playerIndex + 1);

            PrintArray();
        }

        // 左移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 見つからなかった時のために-1で初期化
            int playerIndex = GetPlayerIndex();
            // 要素数はmap.Lengthで取得
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }

            MoveNumber(1, playerIndex, playerIndex - 1);

            PrintArray();
        }
    }
}
