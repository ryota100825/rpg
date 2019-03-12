// Player.cs
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// プレイヤー
public class Player : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;// 移動方向
    [SerializeField] private float moveSpeed = 5.0f;// 移動速度
    public int PlayerHP = 100;
    public Text ScoreText;
    private bool isInvinsible = false;
    GameObject UnityChan;
    [SerializeField]
    private float interval = 0.2f;

    private void Awake()
    {
        UnityChan = transform.GetChild(0).gameObject;

    }

    void Start()
    {
        ScoreText.text = "HP : 100";
    }

    void Update()
    {
        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;

        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {       // プレイヤーの回転(transform.rotation)の更新
            // 無回転状態のプレイヤーのZ+方向(後頭部)を、移動の反対方向(velocity)に回す回転とします
            transform.rotation = Quaternion.LookRotation(velocity);

            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込みます
            transform.position += velocity;
        }

        ScoreText.text = "HP : " + PlayerHP.ToString();
    }

    void OnTriggerEnter(Collider colider)//当たり判定
    {
        if (colider.gameObject.tag == "Enemy")
        {
            if (!isInvinsible)
            {
                StartCoroutine(DamageCoroutine());
            }
        }
        if (colider.gameObject.tag == "Item")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DamageCoroutine()
    {
        isInvinsible = true;
        Debug.Log("apply damage");
        PlayerHP = PlayerHP - 5;
        StartCoroutine(BlinkCoroutine(interval));
        yield return new WaitForSeconds(3f);
        Debug.Log("end invinsible");
        isInvinsible = false;
    }

    IEnumerator BlinkCoroutine(float waitSecond)
    {
        while (isInvinsible)
        {
            UnityChan.SetActive(!UnityChan.activeSelf);

            yield return new WaitForSeconds(waitSecond);
        }
        UnityChan.SetActive(true); // 消えてしまわないように強制でtrueにする
        yield break;
    }
}