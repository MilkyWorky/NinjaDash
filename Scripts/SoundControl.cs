using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{

    [SerializeField]
    private AudioSource theSource;
    [SerializeField]
    private AudioClip jump;
    [SerializeField]
    private AudioClip sound;

    private void Start()
    {
        theSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
      
    }

}
