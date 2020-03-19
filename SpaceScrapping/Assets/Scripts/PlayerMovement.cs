using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float movementSpeed;
    public int score;
    public Text countText;
    public Text gameoverText1;
    public Text gameoverText2;
    public RawImage gameoverBackground;


    private Transform tf;
    private SpinFree shipSpinner;
    

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        shipSpinner = gameObject.GetComponentInParent<SpinFree>();
        score = 0;
        SetCountText();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(UnityEngine.KeyCode.W))
        {
            shipSpinner.transform.Rotate(new Vector3(1,0,0), rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(UnityEngine.KeyCode.S))
        {
            shipSpinner.transform.Rotate(new Vector3(-1,0,0), rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(UnityEngine.KeyCode.D))
        {
            tf.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetKey(UnityEngine.KeyCode.A))
        {
            tf.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetKey(UnityEngine.KeyCode.E))
        {
            if(-shipSpinner.speed <= maxSpeed)
                shipSpinner.speed = shipSpinner.speed + (-5.0f * Time.deltaTime) ;
        }
        else if (Input.GetKey(UnityEngine.KeyCode.Q))
        {
            if(-shipSpinner.speed >= minSpeed)
                shipSpinner.speed = shipSpinner.speed - (-5.0f * Time.deltaTime);
        }
        
    }

   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetCountText();
        }
        else if (other.gameObject.tag == "Doom")
        {

            StartCoroutine(Upload());
            gameoverBackground.gameObject.SetActive(true);
            SetGameoverText();
            gameoverText1.gameObject.SetActive(true);
            gameoverText2.gameObject.SetActive(true);
        }
    }

    void SetGameoverText()
    {
        gameoverText1.text = "Conragtulation You just Crashed a billions dollar ship ";
        gameoverText2.text = "Your Score is " + score.ToString();
    }
    void SetCountText()
    {
        countText.text = "Score: " + score.ToString();

    }
    

    IEnumerator Upload()
    {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes(score.ToString());
        UnityWebRequest www = UnityWebRequest.Put("http://localhost/spacescraping/records.php", myData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Upload complete!");
        }
    }
}
