using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSoundManagement : MonoBehaviour
{

    public AudioClip jumpSound;
    public AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            Audio.clip = jumpSound;
            Audio.Play();
        }


    }  
}
