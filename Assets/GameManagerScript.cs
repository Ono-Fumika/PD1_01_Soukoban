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
            // �����Ȃ��������ɏ����A���^�[������B
            return false;
        }
        // �ړ���ɔ�����������
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

    // �z��̐錾
    int[] map;

    // Start is called before the first frame update
    void Start()
    {
        // �z��̎��Ԃ̐����Ə�����
        map = new int[] { 0, 0, 2, 1, 0, 2, 0, 0, 0 };
        // �ǉ��B������̐錾�Ə�����
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        // �E�ړ�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // ������Ȃ��������̂��߂�-1�ŏ�����
            int playerIndex = GetPlayerIndex();
            // �v�f����map.Length�Ŏ擾
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

        // ���ړ�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // ������Ȃ��������̂��߂�-1�ŏ�����
            int playerIndex = GetPlayerIndex();
            // �v�f����map.Length�Ŏ擾
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
