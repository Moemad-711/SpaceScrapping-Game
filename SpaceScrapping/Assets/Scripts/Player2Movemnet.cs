using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movemnet : MonoBehaviour
{
    public float rotationSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float movementSpeed;
    public int score;
    public Text countText;
    public Text gameoverText;
    public RawImage gameoverBackground;
    public MultiLoader MultiLoader;


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
        if (Input.GetKey(UnityEngine.KeyCode.I))
        {
            shipSpinner.transform.Rotate(new Vector3(1, 0, 0), rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(UnityEngine.KeyCode.K))
        {
            shipSpinner.transform.Rotate(new Vector3(-1, 0, 0), rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(UnityEngine.KeyCode.L))
        {
            tf.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetKey(UnityEngine.KeyCode.J))
        {
            tf.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetKey(UnityEngine.KeyCode.O))
        {
            if (-shipSpinner.speed <= maxSpeed)
                shipSpinner.speed = shipSpinner.speed + (-5.0f * Time.deltaTime);
        }
        else if (Input.GetKey(UnityEngine.KeyCode.U))
        {
            if (-shipSpinner.speed >= minSpeed)
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
            gameoverBackground.gameObject.SetActive(true);
            SetGameoverText();
            gameoverText.gameObject.SetActive(true);
            MultiLoader.GameOverScreen();

        }
    }

    void SetGameoverText()
    {
        gameoverText.text = "Congrats You Crashed a billions dollar spaceship\n " + "Your Score is " + score.ToString();
    }
    void SetCountText()
    {
        countText.text = "Score: " + score.ToString();
    }
}
