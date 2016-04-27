using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public bool isWhiteTurn = true;
    public Text turntxt;
    private CameraMovement cMove;
    string turnState = "Silver";
    public Camera PlayerCam;
    private Color defaultColor;
    public int gameState = 0; // In this state, the code is waiting for : 0 = Piece selection, 1 = Piece animation, 2 = Player2/AI movement
                              //private int activePlayer = 0; // 0 = Player1, 1 = Player2, 2 = AI, to be used later
    private GameObject SelectedPiece; // Selected Piece

    //Update SlectedPiece with the GameObject inputted to this function
    public void SelectPiece(GameObject _PieceToSelect)
    {
        defaultColor = _PieceToSelect.gameObject.GetComponent<Renderer>().material.color;
        if (SelectedPiece)
        {
            SelectedPiece.gameObject.GetComponent<Renderer>().material.color = defaultColor;
        }
        // Change color of the selected piece to make it apparent. Put it back to white when the piece is unselected

        SelectedPiece = _PieceToSelect;
        SelectedPiece.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }

    // Move the SelectedPiece to the inputted coords
    public void MovePiece(Vector3 _coordToMove)
    {
        SelectedPiece.transform.position = _coordToMove; // Move the piece
        SelectedPiece.gameObject.GetComponent<Renderer>().material.color = defaultColor; // Change it's color back
        SelectedPiece = null; // Unselect the Piece
    }

    // Change the state of the game
    public void ChangeState(int _newState)
    {
        gameState = _newState;
        Debug.Log("GameState = " + _newState);
    }
    public void SwitchTurn()
    {
        if (isWhiteTurn == true)
        {
            isWhiteTurn = false;
            turnState = "Black";
            if (PlayerCam.transform.position.y < 16)
            {
                PlayerCam.transform.position = new Vector3(0, 15, 14);
                PlayerCam.transform.eulerAngles = new Vector3(55, 180, 0);
            }
        }
        else if (isWhiteTurn == false)
        {
            isWhiteTurn = true;
            turnState = "Silver";
            if (PlayerCam.transform.position.y < 16)
            {
                PlayerCam.transform.position = new Vector3(0, 15, -14);
                PlayerCam.transform.eulerAngles = new Vector3(55, 0, 0);
            }
        }
        turntxt.text = turnState + "'s Turn";
    }
}
