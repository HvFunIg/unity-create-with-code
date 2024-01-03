using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        // InputField nameInput = gameObject.GetComponent<InputField>();
        nameInput.onEndEdit.AddListener(SubmitName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void SubmitName(string name){
        Debug.Log(name);
        DataManager.Instance.userName = name;
    }
}
