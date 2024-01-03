using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource audioStorage;
    [SerializeField] public AudioClip audioClip1;
    [SerializeField] public AudioClip audioClip2;
    // Start is called before the first frame update
    void Start()
    {
       audioStorage = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                PlayAudio(audioClip1);
                break;
            case "Ground":
                PlayAudio(audioClip1);
                break;
            case "Finish":
                PlayAudio(audioClip2);
                break;
        }
    }
        void PlayAudio(AudioClip clip){
        // audioStorage.clip = clip;
        audioStorage.PlayOneShot(clip);
        Debug.Log("boom");
    }
}
