using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource Boosting;

    // Start is called before the first frame update
    void Start()
    {
       Boosting = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioBoost();
    }

    void AudioBoost(){
        if(Input.GetKey(KeyCode.Space)){
            if(!Boosting.isPlaying){
            Boosting.Play();
            }
        }
        else{
            Boosting.Stop();
        }
    }
}
