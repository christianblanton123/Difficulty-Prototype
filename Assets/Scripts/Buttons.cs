using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    private bool hasParticles;
    private bool hasAudio;
    private bool hasAnimation;
    private bool hasScreenShake;
    private bool hasColor;
    [SerializeField] private Button particles;
    [SerializeField] private Button audio;
    [SerializeField] private Button animation;
    [SerializeField] private Button screenShake;
    [SerializeField] private Button colorButton;
    

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
            screenShake.GetComponent<Image>().color = Color.green;
        } else {
            hasScreenShake = false;
            screenShake.GetComponent<Image>().color = Color.white;
        }
    }

    public void changeHasParticles() {
        if (!getHasParticles()) {
            hasParticles = true;
            particles.GetComponent<Image>().color = Color.green;
        } else {
            hasParticles = false;
            particles.GetComponent<Image>().color = Color.white;
        }
    }

    public void changeHasColor() {
        if (!getHasColor()) {
            hasColor = true;
            colorButton.GetComponent<Image>().color = Color.green;
        } else {
            hasColor = false;
            colorButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void changeHasAudio() {
        if (!getHasAudio()) {
            hasAudio = true;
            FindObjectOfType<AudioManager>().ReturnVolume("Music");
            FindObjectOfType<AudioManager>().swishNoise();
            audio.GetComponent<Image>().color = Color.green;
        } else {
            hasAudio = false;
            FindObjectOfType<AudioManager>().NoVolume("Music");
            audio.GetComponent<Image>().color = Color.white;
        }
    }

}
