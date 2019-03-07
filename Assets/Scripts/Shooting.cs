using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    public Transform startbullet;
    public float speed = 1000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullets = Instantiate(bullet) as GameObject;
            Vector3 posbullet;
            posbullet = this.gameObject.transform.forward * speed;
            bullets.GetComponent<Rigidbody>().AddForce(posbullet);
            bullets.transform.position = startbullet.position;
            Destroy(bullets, 5.0f);
        }
	}
}