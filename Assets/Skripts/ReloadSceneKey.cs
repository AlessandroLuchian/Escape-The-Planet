using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneKey : MonoBehaviour
{
    [SerializeField] private int DeathCount;
    void Update()
    {
        PressRToReloadLevel();
        DeathLimit();
    }

    void ReloadLevel(){
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
        ++DeathCount;
    }
    void PressRToReloadLevel(){
        if(Input.GetKey(KeyCode.R)){
            ReloadLevel();
        }
    }
    void DeathLimit(){
            if(DeathCount==3){
                Debug.Log("Too many Deaths = Restart");
            SceneManager.LoadScene("Over");
        }
    }
}
