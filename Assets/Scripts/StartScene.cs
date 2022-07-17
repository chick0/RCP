using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    }

    void Start()
    {
        this.NameInput.characterLimit = 255;
    }
}
