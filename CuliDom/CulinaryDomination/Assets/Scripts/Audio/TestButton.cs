using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour {

    public Button testButton;

    public GameObject AudioManager;

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
    }

    void Start()
    {
        Button btn = testButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }
}

