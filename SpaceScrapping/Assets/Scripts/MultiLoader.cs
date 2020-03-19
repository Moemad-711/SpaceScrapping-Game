using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiLoader : MonoBehaviour
{

    public Text player1GOText;
    public Text player2GOText;
    public PlayerMovement player1;
    public Player2Movemnet player2;
    public RawImage gameOverRI;
    public Text FGO1Text;
    public Text FGO2Text;

    
    // Update is called once per frame
    public void GameOverScreen()
    {
        
        if (player1GOText.IsActive() && player2GOText.IsActive())
        {
            SetFGOText();
            gameOverRI.gameObject.SetActive(true);
            FGO1Text.gameObject.SetActive(true);
            FGO2Text.gameObject.SetActive(true);
            if (Input.GetKeyDown(UnityEngine.KeyCode.A))
            {
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKeyDown(UnityEngine.KeyCode.B))
            {
                SceneManager.LoadScene(3);
            }
            else if (Input.GetKeyDown(UnityEngine.KeyCode.C))
            {
                SceneManager.LoadScene(0);
            }

        }
    }
    void SetFGOText()
    {
        if (player1.score > player2.score)
        {
            FGO1Text.text = "The Winner is Player 1";
            FGO2Text.text = "Press 1 for Selection Menu, 2 to play again or 3 for login screen";
        }
        else if (player1.score < player2.score)
        {
            FGO1Text.text = "The Winner is Player 2";
            FGO2Text.text = "Press A for Selection Menu, B to play again or C for login screen";
        }
    }
}
