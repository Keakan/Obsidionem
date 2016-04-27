using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridMovement : MonoBehaviour
{

    private Camera PlayerCam; // Camera used by the player
    private GameManager _GameManager; // GameObject responsible for the management of the game
    int sTeam = 10;
    int bTeam = 10;
    public Text vtxt;
    public GameObject victory;

    Vector3 selectedCoord;

    // Use this for initialization
    void Start()
    {
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // Find the Camera's GameObject from its tag
        _GameManager = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Look for Mouse Inputs
        GetMouseInputs();
    }

    // Detect Mouse Inputs
    void GetMouseInputs()
    {
        Ray _ray;
        RaycastHit _hitInfo;


        // Select a piece if the gameState is 0 or 1
        if (_GameManager.gameState < 2)
        {
            // On Left Click
            if (Input.GetMouseButtonDown(0))
            {
                _ray = PlayerCam.ScreenPointToRay(Input.mousePosition); // Specify the ray to be casted from the position of the mouse click

                // Raycast and verify that it collided
                if (Physics.Raycast(_ray, out _hitInfo))
                {
                    // Select the piece if it has the good Tag
                    if ((_hitInfo.collider.gameObject.tag == ("White")) && _GameManager.isWhiteTurn == true)
                    {
                        _GameManager.SelectPiece(_hitInfo.collider.gameObject);
                        _GameManager.ChangeState(1);
                    }
                    else if ((_hitInfo.collider.gameObject.tag == ("Black")) && _GameManager.isWhiteTurn == false)
                    {
                        _GameManager.SelectPiece(_hitInfo.collider.gameObject);
                        _GameManager.ChangeState(1);
                    }
                }
            }
        }

        // Move the piece if the gameState is 1
        if (_GameManager.gameState == 1)
        {
            // On Left Click
            if (Input.GetMouseButtonDown(0))
            {
                _ray = PlayerCam.ScreenPointToRay(Input.mousePosition); // Specify the ray to be casted from the position of the mouse click

                // Raycast and verify that it collided
                if (Physics.Raycast(_ray, out _hitInfo))
                {
                    if (_hitInfo.collider.gameObject.tag == ("Cube"))
                    {
                        selectedCoord = new Vector3(_hitInfo.collider.gameObject.transform.position.x, 3, _hitInfo.collider.gameObject.transform.position.z);
                        _GameManager.MovePiece(selectedCoord);
                        _GameManager.ChangeState(0);

                        _GameManager.SwitchTurn();
                    }
                    else if (_hitInfo.collider.gameObject.tag == ("Tile"))
                    {
                        selectedCoord = new Vector3(_hitInfo.collider.gameObject.transform.position.x, 3, _hitInfo.collider.gameObject.transform.position.z);
                        _GameManager.MovePiece(selectedCoord);
                        _GameManager.ChangeState(0);

                        _GameManager.SwitchTurn();
                    }
                    if (((_hitInfo.collider.gameObject.tag == ("White")) && _GameManager.isWhiteTurn == false)
                        || ((_hitInfo.collider.gameObject.tag == ("Black")) && _GameManager.isWhiteTurn == true))
                    {
                        Kill(_hitInfo);
                    }
                }

            }
        }
    }
    void Kill(RaycastHit other)
    {
        selectedCoord = other.transform.position;
        _GameManager.MovePiece(selectedCoord);
        _GameManager.ChangeState(0);

        _GameManager.SwitchTurn();
        Destroy(other.collider.gameObject);
        if (other.collider.gameObject.tag == "White")
            sTeam--;
        else if (other.collider.gameObject.tag == "Black")
            bTeam--;
        if (bTeam == 0)
        {
            vtxt.text = "Silver Wins";
            victory.gameObject.SetActive(true);
        }
        if (sTeam == 0)
        {
            vtxt.text = "Black Wins";
            victory.gameObject.SetActive(true);
        }
    }
}