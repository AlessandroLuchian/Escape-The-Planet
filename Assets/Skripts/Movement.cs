using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
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
        if(Input.GetKey(KeyCode.A)){
            Debug.Log("Rotating Left");
        }
        else if(Input.GetKey(KeyCode.D)){
            Debug.Log("Rotating Right");
        }
    }
}
