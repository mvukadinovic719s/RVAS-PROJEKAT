using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LogIn : MonoBehaviour
{
    public static string username = "";
    public GameObject txtValidation;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LogInUsername(GameObject txtUsername)
    {
        if (txtUsername.GetComponent<Text>().text.Count() >= 3)
        {
            username = txtUsername.GetComponent<Text>().text;
            print(username);
            SceneManager.LoadScene(1);
        }
        else
        {
            txtValidation.SetActive(true);
        }
            
        
    }
}
