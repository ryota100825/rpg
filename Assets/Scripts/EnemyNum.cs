using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNum : MonoBehaviour {
    int count;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(count);
        if (count == 0)
        {
            Destroy(this.gameObject);
        }
	}
}
