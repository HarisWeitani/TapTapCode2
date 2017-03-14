using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//buylogic succeed

public class ButtonManager : MonoBehaviour
{
    //BUTTON INI BLOM JALAN KALO TOUCH INPUT , MASIH MENCARI SOLUSI

    //item price
    private int[] priceCPU = new int[] { 100, 300, 500, 700, 900 };
    private int[] priceGPU = new int[] { 100, 300, 500, 700, 900 };
    private int[] pricePSU = new int[] { 100, 300, 500, 700, 900 };
    private int[] priceRAM = new int[] { 100, 300, 500, 700, 900 };

    //software price
    private int[] softwarePrice = new int[] { 200, 400, 600, 800, 1000 };
    //ada req buat beli software

    //nanti di taro di button masing masing item
    public int indexCPU;
    public int indexGPU;
    public int indexPSU;
    public int indexRAM;

    public int indexSoftware;

    private int flag = 0;

    //buat kasih index ke berapa nanti biar di access di gamecontroller
    //nanti tiap button di ganti di inspector
    public void cpuIndex(int index)
    {
        //Buy(index);

        GameObject buying = GameObject.Find("GameController");
        GameController buy = buying.GetComponent<GameController>();

        Debug.Log("Money Now : Price Now = " + buy.money +" " +priceCPU[index]);
        if( buy.money >= priceCPU[index])
        {
            buy.money -= priceCPU[index];

            indexCPU = index;
            Debug.Log("Buy Succeed Your money : " +buy.money);
        }
        else
        {
            Debug.Log("Not Enough Money "+indexCPU);
        }
        

    }

    public void gpuIndex(int index)
    {
        GameObject buying = GameObject.Find("GameController");
        GameController buy = buying.GetComponent<GameController>();

        if (buy.money >= priceGPU[index])
        {
            buy.money -= priceGPU[index];

            indexGPU = index;
            Debug.Log("Buy Succeed;");
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }

    public void psuIndex(int index)
    {
        GameObject buying = GameObject.Find("GameController");
        GameController buy = buying.GetComponent<GameController>();

        if (buy.money >= pricePSU[index])
        {
            buy.money -= pricePSU[index];

            indexPSU = index;
            Debug.Log("Buy Succeed;");
        }
        else
        {
            Debug.Log("Not Enough Money");
        }

    }

    public void ramIndex(int index)
    {
        GameObject buying = GameObject.Find("GameController");
        GameController buy = buying.GetComponent<GameController>();

        if (buy.money >= priceRAM[index])
        {
            buy.money -= priceRAM[index];

            indexRAM = index;
            Debug.Log("Buy Succeed;");
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }
    public void softwareIndex (int index)
    {

    }


    /*void Buy(int index)
    {
        GameObject buying = GameObject.Find("GameController");
        GameController buy = buying.GetComponent<GameController>();
        //check if money is enough
        


        //if enough buy index ganti ke baru duit kurang

        //else index btnManager=indexCPU sekarang keluar popup you cant buy this shit


    }*/

    //buat tombol hw dan sw
    public void hardwareBtn(string level)
    {
        SceneManager.LoadScene(level);
        Debug.Log("Level Hardware");
    }
    
    public void softwareBtn(string level)
    {
        SceneManager.LoadScene(level);
        Debug.Log("Level Software");
    }

}
