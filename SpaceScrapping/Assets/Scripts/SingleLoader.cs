using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingleLoader : MonoBehaviour
{
    public RawImage gameoverBackground;
    public Text gameoverText3;
    // Start is called before the first frame update
    void Start()
    {
        SetgameoverText3();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameoverBackground.IsActive())
        {
            gameoverText3.gameObject.SetActive(true);

            if (Input.GetKeyDown(UnityEngine.KeyCode.A))
            {
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKeyDown(UnityEngine.KeyCode.B))
            {
                SceneManager.LoadScene(2);
            }
            else if (Input.GetKeyDown(UnityEngine.KeyCode.C))
            {
                SceneManager.LoadScene(0);
            }

        }
    }
    void SetgameoverText3()
    {
        gameoverText3.text = "Press A for Selection Menu, B to play again or C for login screen";
    }


}
