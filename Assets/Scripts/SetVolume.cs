using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioMixer mixer;

    public void SetLevel (float sliderValue)

    {
        mixer.SetFloat ("Volume", Mathf.Log10 (sliderValue) * 20);
    }
}
