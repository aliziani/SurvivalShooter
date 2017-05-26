using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    public InputField nameTextbox;
    
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(nameTextbox.text))
        {
            PlayerData.Init(nameTextbox.text);
            SceneManager.LoadScene("Level01");
        }
    }

}
