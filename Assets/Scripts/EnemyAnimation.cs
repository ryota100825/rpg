using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private const string key_IsDamage = "IsDamage";

    // Use this for initialization
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.animator.SetBool(key_IsDamage, true);
        }else{
            this.animator.SetBool(key_IsDamage, false);
        }
    }
}
