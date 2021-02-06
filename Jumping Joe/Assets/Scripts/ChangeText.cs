using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI txt;
    
    void Start()
    {
       txt.text = "LEVEL: " + (SceneManager.GetActiveScene().buildIndex -1);
    }
}
