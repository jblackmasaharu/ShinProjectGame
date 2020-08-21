using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingController : MonoBehaviour
{
    public GameObject Ball;
    Rigidbody rbBall;
    public float power = 10f;
    private int shotCount;
    const int shotCountMax = 3;
    public GameObject ballNumbertext;

    CharacterController ccPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbBall = Ball.GetComponent<Rigidbody>();
        ccPlayer = transform.root.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bowlingThrow();
    }

    public void bowlingThrow()
    {
        if (Input.GetMouseButtonDown(0))    // マウスを左クリックした時
        {
            Vector3 arm = transform.position;
            arm.y -= -1;

            shotCount++;

            if (shotCount <= shotCountMax)
            {
                rbBall = Instantiate(Ball, arm, transform.rotation).GetComponent<Rigidbody>(); // 玉を生成
                rbBall.AddForce(ccPlayer.velocity * power + transform.forward, ForceMode.Impulse); // プレイヤーの前方に力を加える
            }


        }

    }

}
