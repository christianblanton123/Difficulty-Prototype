using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    private bool hasParticles;
    private bool hasAudio;
    private bool hasAnimation;
    private bool hasScreenShake;
    private bool hasColor;


    public Buttons() {

    }

    // Start is called before the first frame update
    void Start()
    {
        hasParticles = false;
        hasAudio = false; 
        hasAnimation = false;
        hasScreenShake = false;
        hasColor = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getHasScreenShake() {
        return hasScreenShake;
    }
    public bool getHasAnimation()
    {
        return hasAnimation;
    }

    public bool getHasParticles() {
        return hasParticles;
    }

    public bool getHasColor() {
        return hasColor;
    }

    public bool getHasAudio() {
        return hasAudio;
    }
    public void changeHasAnimation()
    {
        hasAnimation = !hasAnimation;
    }
    public void changeHasScreenShakeState() {
        if (!getHasScreenShake()) {
            hasScreenShake = true;
        } else {
            hasScreenShake = false;
        }
    }

    public void changeHasParticles() {
        if (!getHasParticles()) {
            hasParticles = true;
        } else {
            hasParticles = false;
        }
    }

    public void changeHasColor() {
        if (!getHasColor()) {
            hasColor = true;
        } else {
            hasColor = false;
        }
    }

    public void changeHasAudio() {
        if (!getHasAudio()) {
            hasAudio = true;
            FindObjectOfType<AudioManager>().ReturnVolume("Music");
            FindObjectOfType<AudioManager>().swishNoise();
        } else {
            hasAudio = false;
            FindObjectOfType<AudioManager>().NoVolume("Music");
        }
    }

}
