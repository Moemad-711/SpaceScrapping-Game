using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Web : MonoBehaviour
{
    public InputField uif;
    public InputField sif;


    void Start()
    {
    }

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/spacescraping/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                

         
                    Debug.Log(www.downloadHandler.text);
                    SceneManager.LoadScene(1);
                
            }
        }
    }

    
    public IEnumerator Register(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/spacescraping/signup.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
              
                Debug.Log(www.downloadHandler.text);
                uif.text = "";
                sif.text = "";
            }
        }
    }
}
