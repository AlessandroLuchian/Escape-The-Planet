using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    private MeshRenderer playerRenderer;
    private Transform playerTransform;
    Color defaultColor;

    [SerializeField]private float secondDelay = 0f;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        playerRenderer = GetComponent<MeshRenderer>();
        playerTransform = GetComponent<Transform>();
        defaultColor = playerRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Boost();
        Mover();
    }

    void Boost(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up*Time.deltaTime*moveSpeed);
        }
    }

    void Mover(){
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(moveSpeed);
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-moveSpeed);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
    }

    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                    playerCrashSequence();
                break;
            
            case "Ground":
            /*  playerTransform.position = new Vector3(-10f, 5f, 0f);
                enabled = true;
                playerTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                rb.velocity = Vector3.zero; 
                playerRenderer.material.color = defaultColor; */
                playerCrashSequence();
                break;
            
            case "Finish":
            /*  playerTransform.position = new Vector3(-10f, 5f, 0f);
                playerTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                rb.velocity = Vector3.zero; */
                delayLoadNextLevel();
                break;
        }
    }

    void playerCrashSequence(){
        playerRenderer.material.color = new Color(1f, 0f, 0f, 1f);
        enabled = false;
        Invoke("reloadLevel", secondDelay);
    }
    void reloadLevel(){
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }

    void delayLoadNextLevel(){
        enabled = false;
        Invoke("loadNextLevel", secondDelay);
    }
    void loadNextLevel(){
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = CurrentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
