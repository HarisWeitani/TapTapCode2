using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TODO LIST : ada req buat beli software

public class GameController : MonoBehaviour
{
    //public GameObject objectToSpawn;

    //item variable
    public int money;
    private float happiness;
    //tdpnya | Not used YET
    private int[] CPU = new int[] { 0, 75, 150, 95, 125, 150 };
    private int[] GPU = new int[] { 0, 35, 40, 75, 90, 100, 120, 150, 200 };
    private int[] PSU = new int[] { 0, 400, 550, 650, 750, 850, 1000 };
    private int[] RAM = new int[] { 0, 5, 5, 5, 5, 5, 5 };

    //software income tap
    private int[] softwareTap = new int[] { 10, 15, 30, 50, 100,
                                            150, 200, 250, 300, 350,
                                            400, 450, 500, 550, 600,1000};
    private int[] softwarePassive = new int[] { 25, 50, 100, 200, 400,
                                                500, 600, 700, 800, 900,
                                                1000, 1100, 1200, 1300, 1400, 1500 };

    //item price
    private int[] priceCPU = new int[] { 0, 1000, 3000, 5000, 7500, 10000 };
    private int[] priceGPU = new int[] { 0, 750, 1500, 3000, 5000, 8000, 10000, 15000, 20000 };
    private int[] pricePSU = new int[] { 0, 300, 1000, 1500, 1750, 2000, 3000 };
    private int[] priceRAM = new int[] { 0, 125, 250, 500, 750, 1000, 1500 };

    //software price
    private int[] priceSoftware = new int[] { 0, 2000, 3000, 3500, 4500,
                                             5500, 5000, 6500, 7500, 6000,
                                            7750, 8500, 7500, 8000, 10000 };

    //menyimpan data index buat saving
    public int indexCPU;
    public int indexGPU;
    public int indexPSU;
    public int indexRAM;

    public int indexSoftware;
    //private int indexSoftwarePassive;

    //key buat save
    private string saveData = "HasKey";
    //cek ada save data/ga
    private int checkSave; //gw ga ngerti knp valuenya 0 terus , tapi ini bekerja jadi jangan ditanyakan #taboo

    //delta time
    private float period = 0.0f;

    //PopUp Text
    public GameObject popUpHw;
    public GameObject popUpSw;
    public Canvas canvasHw;
    public Canvas canvasSw;


    void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey(saveData))
        {
            Debug.Log("Load save data " + saveData + " " + checkSave);
            Load();
            Debug.Log("cpu index " + indexCPU);
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

        if (period > 1)
        {
            money += softwarePassive[indexSoftware];
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;

        if (screenLeftClicked())
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0.0f;
            //Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));

            //duit yang didapat sesuai software yang dimiliki
            money += softwareTap[indexSoftware];

            Debug.Log("On Screen Click");
            Debug.Log("money " + money);
            Debug.Log("index CPU " + indexCPU);
        }
    }

    private static bool screenLeftClicked()
    {
        return Input.GetMouseButtonDown(0);
    }

    void OnApplicationQuit()
    {
        Save();
        Debug.Log("On Application Quit Save");
    }

    //save Load logic start
    void Save()
    {
        SaveMoneyAndHappiness();
        SaveUpgrades();
        //PlayerPrefs.SetInt("swpKey", indexSoftwarePassive);

        Debug.Log("Save Data index cpu " + indexCPU);
    }

    private void SaveUpgrades()
    {
        //save upgradean
        checkSave = 1;
        PlayerPrefs.SetInt(saveData, checkSave);
        PlayerPrefs.SetInt("cpuKey", indexCPU);
        PlayerPrefs.SetInt("gpuKey", indexGPU);
        PlayerPrefs.SetInt("psuKey", indexPSU);
        PlayerPrefs.SetInt("ramKey", indexRAM);

        PlayerPrefs.SetInt("swKey", indexSoftware);
    }

    private void SaveMoneyAndHappiness()
    {
        //save money&happiness
        PlayerPrefs.SetInt("moneyKey", money);
        PlayerPrefs.SetFloat("hepiKey", happiness);
    }

    void Load()
    {
        LoadMoneyAndHappiness();
        LoadUpgrades();
        //indexSoftwarePassive = PlayerPrefs.GetInt("swpKey");

        Debug.Log("Load Data index cpu " + indexCPU);
    }

    private void LoadUpgrades()
    {
        //load upgradean
        indexCPU = PlayerPrefs.GetInt("cpuKey");
        indexGPU = PlayerPrefs.GetInt("gpuKey");
        indexPSU = PlayerPrefs.GetInt("psuKey");
        indexRAM = PlayerPrefs.GetInt("ramKey");

        indexSoftware = PlayerPrefs.GetInt("swKey");
    }

    private void LoadMoneyAndHappiness()
    {
        //load money&happiness
        money = PlayerPrefs.GetInt("moneyKey");
        happiness = PlayerPrefs.GetFloat("hepiKey");
    }

    //save Load logic end

    //buy logic start
    public void cpuIndex(int index)
    {
        LogMoneyWithPrice(priceCPU[index]);
        if (isMoneyEnoughToBuy(priceCPU[index]) && indexCPU < index)
        {

            money -= priceCPU[index];

            indexCPU = index;
            Debug.Log("Buy Succeed Your money : " + money);
        }
        else
        {
            PopUpHw();
            Debug.Log("Can't Buy this shit" + indexCPU);
        }
    }

    private void LogMoneyWithPrice(int priceIndex)
    {
        Debug.Log("Money Now : Price Now = " + money + " " + priceIndex);
    }

    private bool isMoneyEnoughToBuy(int price)
    {
        return money >= price;
    }

    public void gpuIndex(int index)
    {
        LogMoneyWithPrice(priceGPU[index]);

        if (isMoneyEnoughToBuy(priceGPU[index]) && indexGPU < index)
        {
            money -= priceGPU[index];

            indexGPU = index;
            Debug.Log("Buy Succeed;");
        }
        else
        {
            PopUpHw();
            Debug.Log("Not Enough Money");
        }
    }

    public void psuIndex(int index)
    {
        LogMoneyWithPrice(pricePSU[index]);

        if (isMoneyEnoughToBuy(pricePSU[index]) && indexPSU < index)
        {
            money -= pricePSU[index];

            indexPSU = index;

            Debug.Log("Buy Succeed;");
        }
        else
        {
            PopUpHw();
            Debug.Log("Not Enough Money");
        }

    }

    public void ramIndex(int index)
    {
        LogMoneyWithPrice(priceRAM[index]);

        if (isMoneyEnoughToBuy(priceRAM[index]) && indexRAM < index)
        {
            money -= priceRAM[index];

            indexRAM = index;

            Debug.Log("Buy Succeed");
        }
        else
        {
            PopUpHw();
            Debug.Log("Not Enough Money");
        }
    }

    public void softwareIndex(int index)
    {
        LogMoneyWithPrice(priceSoftware[index]);

        if (isMoneyEnoughToBuy(priceSoftware[index]) && indexSoftware < index)
        {
            money -= priceSoftware[index];

            indexSoftware = index;
            //indexSoftwarePassive = index;
            Debug.Log("Buy Succeed " + money + " " + indexSoftware);
        }
        else
        {
            PopUpSw();
            Debug.Log("Not Enough Money " + indexSoftware);
        }
    }
    //buy logic end

    //Pop Up Start
    public void showPopUp(GameObject popupItem, Vector3 position)
    {
        GameObject inst = Instantiate(popupItem, position, Quaternion.identity);
        inst.transform.SetParent(canvasHw.transform, false);
        inst.transform.localScale = new Vector3(2, 2, 2);
        Destroy(inst, 1.0f);
    }

    public void PopUpHw()
    {
        Vector3 position = new Vector3(380, -180, 0);
        showPopUp(popUpHw, position);
    }

    public void PopUpSw()
    {
        Vector3 position = new Vector3(400, -135, 0);
        showPopUp(popUpSw, position);
    }
    //Pop Up end

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
