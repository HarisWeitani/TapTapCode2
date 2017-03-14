using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    //menyimpan data index buat saving
    private int indexCPU;
    private int indexGPU;
    private int indexPSU;
    private int indexRAM;

    private int indexSoftware;

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

    void Save()
    {
        //access ButtonManager Variable
        GameObject indexing = GameObject.Find("ButtonManager");
        ButtonManager btnManager = indexing.GetComponent<ButtonManager>();

        indexCPU = btnManager.indexCPU;
        indexGPU = btnManager.indexGPU;
        indexPSU = btnManager.indexPSU;
        indexRAM = btnManager.indexRAM;

        indexSoftware = btnManager.indexSoftware;
        
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
