using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextMoney : MonoBehaviour
{

    public Text moneyText;
    public Text moneyHardware;
    public Text moneySoftware;

    public Text indexCpuText;
    public Text indexGpuText;
    public Text indexPsuText;
    public Text indexRamText;
    public Text indexSoftwareText;

    string[] cpuVersion = new string[] { "Single Core", "Dual Core", "Quad Core", "Hexa Core", "Octa Core", "10-Core" };
    string[] gpuVersion = new string[] { "Second-Hand", "Regular", "Analog Alliance", "Cotac COM", "Megabye SkyForce", "E-GPU For The Lost", " HSI Twin Fire", "Osas Strike" };
    string[] psuVersion = new string[] { "Second-Hand", "Regular", "OceanSonic", "Be Loud", "SilverSteel", "Thermal Drill", "Hotter Shifu" };
    string[] ramVersion = new string[] { "Second-Hand", "Regular", "X-Gen Value", "G.Skull Rip-Aim", "CrossAIR Genuine", "QueenStone Rage" };
    string[] softwareVersion = new string[] { "Coding Studio 1.0", "Coding Studio 2.0", "Coding Studio 3.0",
                                              "Cobra 1.0", "Cobra 2.0", "Cobra 3.0",
                                              "Emerald 1.0", "Emerald 2.0", "Emerald 3.0",
                                              "WarFox GameMaker 1.0", "WarFox GameMaker 2.0", "WarFox GameMaker 3.0",
                                              "Dyno FrozenWeaver 1.0", "Dyno FrozenWeaver 2.0", "Dyno FrozenWeaver 3.0",
                                            };

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

        indexCpuText.text = "Cpu Version : " + cpuVersion[index.indexCPU];
        indexGpuText.text = "Gpu Version : " + gpuVersion[index.indexGPU];
        indexPsuText.text = "Psu Version : " + psuVersion[index.indexPSU];
        indexRamText.text = "Ram Version : " + ramVersion[index.indexRAM];
        indexSoftwareText.text = "Software Version : " + softwareVersion[index.indexSoftware];
    }

    void setMoney()
    {
        GameObject money = GameObject.Find("GameController");
        GameController moneyCount = money.GetComponent<GameController>();

        moneyText.text = "Rp: " + moneyCount.money.ToString() + "K";
        moneyHardware.text = moneySoftware.text = moneyText.text;
    }

}
