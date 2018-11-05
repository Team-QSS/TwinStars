using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenButton : MonoBehaviour
{
    KeyCode[] keycode;

    private void Start() // ↑ ↑ ↓ ↓ ← → ← → B A
    {
        keycode = new KeyCode[10];
        keycode[0] = KeyCode.UpArrow;
        keycode[1] = KeyCode.UpArrow;
        keycode[2] = KeyCode.DownArrow;
        keycode[3] = KeyCode.DownArrow;
        keycode[4] = KeyCode.LeftArrow;
        keycode[5] = KeyCode.RightArrow;
        keycode[6] = KeyCode.LeftArrow;
        keycode[7] = KeyCode.RightArrow;
        keycode[8] = KeyCode.B;
        keycode[9] = KeyCode.A;
    }

    public void ButtonE()
    {
        StartCoroutine(Command());
    }

    IEnumerator Command()
    {
        int i = 0;

        while(true)
        {
            if(Input.GetKey(keycode[i]))
            {
                i++;
                if(i == 10)
                {
                    HiddenStage();
                    break;
                }
            }
            yield return null;
        }
    }

    private void HiddenStage()
    {
        GameState.StageLevel = 51;
        SceneManager.LoadScene("GameStage");
    }
}
