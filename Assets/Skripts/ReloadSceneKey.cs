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
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    void PressRToReloadLevel(){
        if(Input.GetKey(KeyCode.R)){
            ReloadLevel();
        }
    }
}
