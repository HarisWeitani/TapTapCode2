using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextMoney : MonoBehaviour {

    public Text moneyText;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        setMoney();
    }

    void Update()
    {
        setMoney();
    }

    void setMoney()
    {
        GameObject money = GameObject.Find("GameController");
        GameController moneyCount = money.GetComponent<GameController>();

        moneyText.text = moneyCount.money.ToString() + ": Money";

    }

}
