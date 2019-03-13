using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeScript : MonoBehaviour {
    public AudioClip bgm;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        audio.PlayOneShot(bgm);
		
	}
}
