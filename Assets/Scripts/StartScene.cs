using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class StartScene : MonoBehaviour
{
    public TMP_InputField NameInput;

    public void onStartClick()
    {
        string name = this.NameInput.text.Trim();

        if (name.Length != 0)
        {
            Director.Name = name;
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            bool ask = EditorUtility.DisplayDialog(
                "이름",
                "게임을 시작하려면 이름을 입력해야 합니다.", 
                "이름 입력하기",
                "익명으로 계속하기"
            );

            if (ask == false)
            {
                Director.Name = "ㅇㅇ";
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    void Start()
    {
        this.NameInput.characterLimit = 255;
    }
}
