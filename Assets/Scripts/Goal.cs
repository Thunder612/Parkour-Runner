using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public GameObject GoalObject;
    public Text GoalText;
    public GameObject Timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GoalObject.SetActive(true);
        //GoalText.text = "Victory! Your Time: " + string.Format("{0:00} : {1:00}", Mathf.FloorToInt(Time.deltaTime / 60), Mathf.FloorToInt(Time.deltaTime % 60));
        GoalText.text = "Victory! Your Time: " + Timer.GetComponent<Timer>().timerText.text;
    }
}
