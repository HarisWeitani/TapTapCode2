using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextMoney : MonoBehaviour {

    public Text moneyText;
    public Text moneyHardware;
    public Text moneySoftware;

    public Text indexCpuText;
    public Text indexGpuText;
    public Text indexPsuText;
    public Text indexRamText;

    private Rigidbody2D rb2d;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

        setMoney();
        setIndex();
    }

    void Update()
    {
        setIndex();
        setMoney();
    }

    void setIndex()
    {
        GameObject statusBar = GameObject.Find("GameController");
        GameController index = statusBar.GetComponent<GameController>();

        indexCpuText.text = "Cpu Version : " + index.indexCPU.ToString();
        indexGpuText.text = "Gpu Version : " + index.indexGPU.ToString();
        indexPsuText.text = "Psu Version : " + index.indexPSU.ToString();
        indexRamText.text = "Ram Version : " + index.indexRAM.ToString();

    }

    void setMoney()
    {
        GameObject money = GameObject.Find("GameController");
        GameController moneyCount = money.GetComponent<GameController>();

        moneyText.text = "Rp: "+moneyCount.money.ToString() + "K";
        moneyHardware.text = moneySoftware.text = moneyText.text;
    }

}
