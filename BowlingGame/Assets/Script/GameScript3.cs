using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript3 : MonoBehaviour
{
    public Text text;
    public Image textGround;
    GameObject[] pins;
    public float q = 0.01f;
    public GameObject gameCleartext;
    public GameObject RetryButton;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin"); //「Pin」タグのついたオブジェクトを探して、全て配列pinsにいれる

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (text.text == "")
            {
                text.text = CountStandingPins().ToString();
            }
            else
            {
                text.text = "";
            }

        }
        if (pins.Length == 0)
        {
            gameCleartext.SetActive(true);
        }
    }

    int CountStandingPins()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin"); //「Pin」タグのついたオブジェクトを探して、全て配列pinsにいれる

        if (pins.Length == 0)
        {
            return 0;
        }
        else
        {
            int n = 0;

            foreach (GameObject pin in pins)
            {
                if (pin.transform.rotation.x * pin.transform.rotation.x < q && pin.transform.rotation.z * pin.transform.rotation.z < q)
                {
                    n++;
                }
            }
            return n; // 立っているピンの個数を返す
        }

     }

    private void OnCollisionEnter(Collision collision)
    {

    }

}
