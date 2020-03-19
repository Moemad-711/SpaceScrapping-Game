using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Button loginButton;
    public Button signupButton;
    public InputField userInput;
    public InputField passwordInput;
    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(() => { StartCoroutine(Main.instance.web.Login(userInput.text, passwordInput.text)); });
        signupButton.onClick.AddListener(() => { StartCoroutine(Main.instance.web.Register(userInput.text, passwordInput.text)); });
    }

}
