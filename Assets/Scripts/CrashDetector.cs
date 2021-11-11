using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float delayTime = 1f;

    [SerializeField] ParticleSystem crashEffect;

    bool hasCrashed = false;

    [SerializeField] AudioClip crashSFX;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag =="Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            Debug.Log("Ouch!");
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene",delayTime);
        }
    }

    void ReloadScene()
    {
       SceneManager.LoadScene(0);  
    }
}
