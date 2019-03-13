using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    public Transform startbullet;
    public float speed = 500;
    public AudioClip se;
    private AudioSource SeAudio;

	// Use this for initialization
	void Start () {
        SeAudio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullets = Instantiate(bullet) as GameObject;
            SeAudio.PlayOneShot(se);
            Vector3 posbullet;
            posbullet = this.gameObject.transform.forward * speed;
            bullets.GetComponent<Rigidbody>().AddForce(posbullet);
            bullets.transform.position = startbullet.position;
            Destroy(bullets, 1.5f);
        }
	}
}