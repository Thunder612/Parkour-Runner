using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 0f;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = string.Format("{0:00} : {1:00}", Mathf.FloorToInt(timer / 60), Mathf.FloorToInt(timer % 60));
    }
}
