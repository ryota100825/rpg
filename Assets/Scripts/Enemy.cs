using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    public int EnemyHP;//敵HP
    private Vector3 TargetPos;
    private Vector3 EnemyPos;
    private Animator animator;
    private const string key_IsDamage = "IsDamage";
    private const string key_IsAtack = "IsAtack";
    private const string key_IsDeath = "IsDeath";
    GameObject aura;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 0;
        EnemyHP = 10;
        this.animator = GetComponent<Animator>();
        aura = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        TargetPos = target.transform.position;
        EnemyPos = transform.position;
        float dist = Vector3.Distance(TargetPos, EnemyPos);
        if(dist <= 30)
        {
            agent.speed = 2;
        }
        agent.destination = TargetPos;
    }

    void OnTriggerEnter(Collider col)//当たり判定
    {
        if (col.gameObject.tag == "Fire")
        {
            EnemyHP = EnemyHP - 2;
            this.animator.SetBool(key_IsDamage, true);
            Debug.Log(EnemyHP);

            if (EnemyHP <= 0)
            {
                this.animator.SetBool(key_IsDeath, true);
                
                Destroy(this.gameObject,0.5f);
                aura.SetActive(false);
            }
        }
            
    }
}
