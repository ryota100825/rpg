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
    private bool isInvinsible = false;
    private float interval = 0.1f;
    private const string key_IsDamage = "IsDamage";
    private const string key_IsAtack = "IsAtack";
    private const string key_IsDeath = "IsDeath";
    GameObject enemychan;
    public AudioClip se;
    private AudioSource SeAudio;

    private void Awake()
    {
        enemychan = transform.GetChild(0).gameObject;
    }

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 0;
        EnemyHP = 3;
        this.animator = GetComponent<Animator>();
        SeAudio = gameObject.GetComponent<AudioSource>();
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
            if (!isInvinsible)
            {
                StartCoroutine(DamageCoroutine());
            }
            this.animator.SetBool(key_IsDamage, true);
            Debug.Log(EnemyHP);

            if (EnemyHP <= 0)
            {
                this.animator.SetBool(key_IsDeath, true);
                
                Destroy(this.gameObject,0.5f);
            }
        }
            
    }

    IEnumerator DamageCoroutine()
    {
        isInvinsible = true;
        EnemyHP--;
        SeAudio.PlayOneShot(se);
        StartCoroutine(BlinkCoroutine(interval));
        yield return new WaitForSeconds(0.5f);
        isInvinsible = false;
    }

    IEnumerator BlinkCoroutine(float waitSecond)
    {
        while (isInvinsible)
        {
            enemychan.SetActive(!enemychan.activeSelf);

            yield return new WaitForSeconds(waitSecond);
        }
        enemychan.SetActive(true);
        yield break;
    }
}
