using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    public int EnemyHP;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        EnemyHP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
    }

    void OnTriggerEnter(Collider col)//当たり判定
    {
        if (col.gameObject.tag == "Fire")
        {
            EnemyHP = EnemyHP - 2;
            Debug.Log(EnemyHP);
            if (EnemyHP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
