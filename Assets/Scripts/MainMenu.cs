using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject play;
    public GameObject settings;
    public GameObject exit;
    public GameObject store;

    public GameObject single;
    public GameObject multi;

    public GameObject device;
    public GameObject online;
    public GameObject lan;

    public GameObject pieces;
    public GameObject boards;

    public GameObject sound;
    public GameObject presets;
    public GameObject credits;

    public Canvas singleM;
    public Canvas multiM;
    public Canvas deviceM;
    public Canvas onlineM;
    public Canvas lanM;
    public Canvas soundM;
    public Canvas defaultsM;
    public Canvas exitM;

    void Start()
    {
        /*
        play = GameObject.FindGameObjectWithTag("Play");
        settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<GameObject>();
        exit = GameObject.FindGameObjectWithTag("Exit").GetComponent<GameObject>();
        store = GameObject.FindGameObjectWithTag("Store").GetComponent<GameObject>();
        single = GameObject.FindGameObjectWithTag("SingleP").GetComponent<GameObject>();
        multi = GameObject.FindGameObjectWithTag("MultiP").GetComponent<GameObject>();
        device = GameObject.FindGameObjectWithTag("Device").GetComponent<GameObject>();
        online = GameObject.FindGameObjectWithTag("Online").GetComponent<GameObject>();
        lan = GameObject.FindGameObjectWithTag("LAN").GetComponent<GameObject>();
        pieces = GameObject.FindGameObjectWithTag("Pieces").GetComponent<GameObject>();
        boards = GameObject.FindGameObjectWithTag("Boards").GetComponent<GameObject>();
        sound = GameObject.FindGameObjectWithTag("Sounds").GetComponent<GameObject>();
        presets = GameObject.FindGameObjectWithTag("Presets").GetComponent<GameObject>();
        credits = GameObject.FindGameObjectWithTag("Credits").GetComponent<GameObject>();
        */
        //_GameManager = gameObject.GetComponent<GameManager>();

        singleM.enabled = false;
        multiM.enabled = false;
        deviceM.enabled = false;
        onlineM.enabled = false;
        lanM.enabled = false;
        soundM.enabled = false;
        defaultsM.enabled = false;
        exitM.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            single.SetActive(false);
            multi.SetActive(false);
            device.SetActive(false);
            lan.SetActive(false);
            online.SetActive(false);
            presets.SetActive(false);
            sound.SetActive(false);
            credits.SetActive(false);
            boards.SetActive(false);
            pieces.SetActive(false);

            play.SetActive(true);
            settings.SetActive(true);
            exit.SetActive(true);
            store.SetActive(true);
        }
        if (other.gameObject.CompareTag("Play"))
        {
            store.SetActive(false);
            exit.SetActive(false);
            settings.SetActive(false);

            single.SetActive(true);
            multi.SetActive(true);
        }
        if (other.gameObject.CompareTag("SingleP"))
        {
            singleM.enabled = true;
        }
        ///
        //multi
        ///
        if (other.gameObject.CompareTag("MultiP"))
        {
            single.SetActive(false);

            device.SetActive(true);
            lan.SetActive(true);
            online.SetActive(true);
        }
        //////////////////////////////////////
        if (other.gameObject.CompareTag("Device"))
        {
            deviceM.enabled = true;
        }
        if (other.gameObject.CompareTag("Online"))
        {
            onlineM.enabled = true;
        }
        if (other.gameObject.CompareTag("LAN"))
        {
            lanM.enabled = true;
        }
        ///
        //Store
        ///
        if (other.gameObject.CompareTag("Store"))
        {
            pieces.SetActive(true);
            boards.SetActive(true);
        }
        if (other.gameObject.CompareTag("Pieces"))
        {
            boards.SetActive(false);
        }
        if (other.gameObject.CompareTag("Boards"))
        {
            pieces.SetActive(false);
        }

        if (other.gameObject.CompareTag("Credits"))
        {
            Application.Quit();
        }

        if (other.gameObject.CompareTag("Exit"))
        {
            exitM.enabled = true;
            //Debug.Log("Exit");
            //ExitPress();
        }

        if (other.gameObject.CompareTag("Settings"))
        {
            //Camerapos.transform.position = new Vector3(-10, 18, -17);
            sound.SetActive(true);
            presets.SetActive(true);
        }
        if (other.gameObject.CompareTag("Sounds"))
        {
            presets.SetActive(false);
            //
            soundM.enabled = true;
        }
        if (other.gameObject.CompareTag("Presets"))
        {
            sound.SetActive(false);
            //
            defaultsM.enabled = true;
        }
    }
}
