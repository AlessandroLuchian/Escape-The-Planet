using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisablePlayerMovement : MonoBehaviour
{
    [SerializeField] private Movement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update() {
    }
    private void OnCollisionEnter(Collision other) {
       switch (other.gameObject.tag){
            case "Player":
                playerMovement.enabled = false;
                break;
            default:
                ReloadLevel(0);
                break;
       }     
    }

    void ReloadLevel(int CurrentSceneIndex){
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
}
