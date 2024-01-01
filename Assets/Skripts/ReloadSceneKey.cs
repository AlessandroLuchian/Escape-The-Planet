using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneKey : MonoBehaviour
{
    void Update()
    {
        PressRToReloadLevel();
    }

    void ReloadLevel(){
        SceneManager.LoadScene("SandBox");
    }
    void PressRToReloadLevel(){
        if(Input.GetKey(KeyCode.R)){
            ReloadLevel();
        }
    }
}
