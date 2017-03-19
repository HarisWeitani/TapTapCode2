using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//buy logic moved here
public class GameController : MonoBehaviour
{
    //public GameObject objectToSpawn;

    //item variable
    public int money;
    private float happiness;
    //tdpnya
    private int[] CPU = new int[] { 10, 20, 30, 40, 50 };
    private int[] GPU = new int[] { 11, 21, 31, 41, 51 };
    private int[] PSU = new int[] { 12, 22, 32, 42, 52 };
    private int[] RAM = new int[] { 13, 23, 33, 43, 53 };
    //software income/tap
    private int[] softwareTap = new int[] { 50, 100, 150, 200, 250 };

    //item price
    private int[] priceCPU = new int[] { 100, 300, 500, 700, 900 };
    private int[] priceGPU = new int[] { 100, 300, 500, 700, 900 };
    private int[] pricePSU = new int[] { 100, 300, 500, 700, 900 };
    private int[] priceRAM = new int[] { 100, 300, 500, 700, 900 };

    //software price
    private int[] priceSoftware = new int[] { 200, 400, 600, 800, 1000 };
    //ada req buat beli software

    //menyimpan data index buat saving
    public int indexCPU;
    public int indexGPU;
    public int indexPSU;
    public int indexRAM;

    public int indexSoftware;

    //key buat save
    private string saveData = "HasKey";
    //cek ada save data/ga
    private int checkSave; //gw ga ngerti knp valuenya 0 terus , tapi ini bekerja jadi jangan ditanyakan #taboo

    void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey(saveData))
        {
            Debug.Log("Load save data "+ saveData +" "+checkSave);
            Load();
            Debug.Log("cpu index " +indexCPU);
        }
        else
        {
            checkSave = 0;
            Debug.Log("create new Save " + saveData + " " + checkSave);
            Save();
        }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0.0f;
            //Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
            Debug.Log("On Screen Click");
            money += 100;
            Debug.Log("money " +money);
            Debug.Log("index CPU "+indexCPU);
        }

    }

    void OnApplicationQuit()
    {
        Save();
        Debug.Log("On Application Quit Save");
    }

    //save logic start
    void Save()
    {
        //save money&happiness
        PlayerPrefs.SetInt("moneyKey", money);
        PlayerPrefs.SetFloat("hepiKey",happiness);

        //save upgradean
        checkSave = 1;
        PlayerPrefs.SetInt(saveData, checkSave);
        PlayerPrefs.SetInt("cpuKey",indexCPU);
        PlayerPrefs.SetInt("gpuKey",indexGPU);
        PlayerPrefs.SetInt("psuKey",indexPSU);
        PlayerPrefs.SetInt("ramKey",indexRAM);

        PlayerPrefs.SetInt("swKey", indexSoftware);
        Debug.Log("Save Data index cpu " + indexCPU);
    }

    void Load()
    {
        //load money&happiness
        money= PlayerPrefs.GetInt("moneyKey");
        happiness= PlayerPrefs.GetFloat("hepiKey");

        //load upgradean
        indexCPU = PlayerPrefs.GetInt("cpuKey");
        indexGPU = PlayerPrefs.GetInt("gpuKey");
        indexPSU = PlayerPrefs.GetInt("psuKey");
        indexRAM = PlayerPrefs.GetInt("ramKey");

        indexSoftware = PlayerPrefs.GetInt("swKey");
        Debug.Log("Load Data index cpu "+indexCPU);
    }
    //save logic end

    //buy logic start
    public void cpuIndex(int index)
    {
        Debug.Log("Money Now : Price Now = " + money + " " + priceCPU[index]);
        if (money >= priceCPU[index])
        {
            money -= priceCPU[index];

            indexCPU = index;
            Debug.Log("Buy Succeed Your money : " + money);
        }
        else
        {
            Debug.Log("Not Enough Money " + indexCPU);
        }
    }

    public void gpuIndex(int index)
    {
        if (money >= priceGPU[index])
        {
            money -= priceGPU[index];

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
        if (money >= pricePSU[index])
        {
            money -= pricePSU[index];

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
        if (money >= priceRAM[index])
        {
            money -= priceRAM[index];

            indexRAM = index;
            Debug.Log("Buy Succeed");
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }

    public void softwareIndex(int index)
    {
        if(money >= priceSoftware[index])
        {
            money -= priceSoftware[index];

            indexSoftware = index;
            Debug.Log("Buy Succeed");
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }
    //buy logic end

}

// turbo
/*Touch myTouch = Input.GetTouch(0);

Touch[] myTouches = Input.touches;
for (int i = 0; i < Input.touchCount; i++)
{
    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    spawnPosition.z = 0.0f;
    GameObject objectInstance = Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
}
*/
