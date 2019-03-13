using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
    public GameObject target;//NavMeshのターゲット
    public GameObject kabe;
    NavMeshAgent agent;
    public int EnemyHP;//敵HP
    public int count;
    public int bosscount;
    private Animator animator;
    private bool isInvinsible = false;
    private bool isAct = false;
    private float interval = 0.1f;
    GameObject enemychan;
    public AudioClip se;
    private AudioSource SeAudio;
    public GameObject bullet;
    public Transform startbullet;
    public Transform startbullet2;
    public Transform startbullet3;
    public float speed = 500;
    public int bulletcount;


    // Use this for initialization
    void Start () {
        enemychan = transform.GetChild(0).gameObject;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 0;
        EnemyHP = 20;
        this.animator = GetComponent<Animator>();
        SeAudio = gameObject.GetComponent<AudioSource>();
        bulletcount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        agent.destination = target.transform.position;
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(count == 0)
        {
            isAct = true;
            Destroy(kabe);
            agent.speed = 5;
        }
        if (isAct)
        {
            bulletcount++;
            if(bulletcount % 100 == 0)
            {
                BossShot();
                BossShot2();
                BossShot3();
            }
        }
	}

    void OnTriggerEnter(Collider col)//当たり判定
    {
        if (col.gameObject.tag == "Fire")
        {
            if (!isInvinsible)
            {
                StartCoroutine(DamageCoroutine());
            }

            if (EnemyHP <= 0)
            {
                Destroy(this.gameObject, 0.5f);
                SceneManager.LoadScene("GameClear");
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

    public void BossShot()
    {
        GameObject bullets = Instantiate(bullet) as GameObject;
        Vector3 posbullet;
        posbullet = this.gameObject.transform.forward * speed;
        bullets.GetComponent<Rigidbody>().AddForce(posbullet);
        bullets.transform.position = startbullet.position;
        Destroy(bullets, 5.0f);
    }
    public void BossShot2()
    {
        GameObject bullets = Instantiate(bullet) as GameObject;
        Vector3 posbullet;
        posbullet = this.gameObject.transform.forward * speed;
        bullets.GetComponent<Rigidbody>().AddForce(posbullet);
        bullets.transform.position = startbullet2.position;
        Destroy(bullets, 5.0f);
    }
    public void BossShot3()
    {
        GameObject bullets = Instantiate(bullet) as GameObject;
        Vector3 posbullet;
        posbullet = this.gameObject.transform.forward * speed;
        bullets.GetComponent<Rigidbody>().AddForce(posbullet);
        bullets.transform.position = startbullet3.position;
        Destroy(bullets, 5.0f);
    }


}
