using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private const string key_IsRun = "IsRun";
    private const string key_IsAtack = "IsAtack";
    private const string key_IsAtack2 = "IsAtack2";
    private const string key_IsAtack3 = "IsAtack3";
    // Use this for initialization
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.animator.SetBool(key_IsRun, true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.animator.SetBool(key_IsRun, true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.animator.SetBool(key_IsRun, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.animator.SetBool(key_IsRun, true);
        }else{
            this.animator.SetBool(key_IsRun, false);
        }

        if (Input.GetKey(KeyCode.I))
        {
            this.animator.SetBool(key_IsAtack, true);
        }else{
            this.animator.SetBool(key_IsAtack, false);
        }
        if (Input.GetKey(KeyCode.O))
        {
            this.animator.SetBool(key_IsAtack2, true);
        }else
        {
            this.animator.SetBool(key_IsAtack2, false);
        }
        if (Input.GetKey(KeyCode.P))
        {
            this.animator.SetBool(key_IsAtack3, true);
        }else
        {
            this.animator.SetBool(key_IsAtack3, false);
        }
    }
}
