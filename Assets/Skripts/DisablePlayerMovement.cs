using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerMovement : MonoBehaviour
{
    [SerializeField] private Movement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnCollisionEnter(Collision other) {
       if(other.gameObject.CompareTag("Player")){
            playerMovement.enabled = false;
       }     
    }
}
