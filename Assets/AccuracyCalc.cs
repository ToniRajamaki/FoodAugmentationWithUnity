using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccuracyCalc : MonoBehaviour
{

    [SerializeField] GameObject ao;
    [SerializeField] GameObject press_space_object;
    int found;
    int notFound;
    int totalFrames;
    float accuracy;
    [SerializeField] float testingTime;
    float time;
    bool stillTesting;

    [SerializeField] GameObject timer_object;
    TextMeshProUGUI timer;
    
    bool trackingTime;


    [SerializeField] GameObject framesObject;
    TextMeshProUGUI totalFramesText;

    [SerializeField] GameObject foundObject;//success recognitions
    TextMeshProUGUI foundText;

    [SerializeField] GameObject notFoundObject; //failed recognitions
    TextMeshProUGUI notFoundText;

    [SerializeField] GameObject accuracyObject;
    TextMeshProUGUI accuracyText;
    // Start is called before the first frame update
    void Start()
    {
        time = testingTime;
        trackingTime = false;
        stillTesting = false;
        timer = timer_object.GetComponent<TextMeshProUGUI>();
        timer.text = testingTime.ToString();
        totalFramesText = framesObject.GetComponent<TextMeshProUGUI>();
        foundText = foundObject.GetComponent<TextMeshProUGUI>();
        accuracyText = accuracyObject.GetComponent<TextMeshProUGUI>();
        notFoundText = notFoundObject.GetComponent<TextMeshProUGUI>();

        found = 0;
        notFound = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            press_space_object.active = false;
            stillTesting = true;
            Invoke("StopTesting", testingTime);
            trackingTime = true;

        }


        if (trackingTime)
        {
            if (time > 0f)
            {
                time -= Time.deltaTime;

                timer.text = System.Math.Round(time,1).ToString();
            }
            else
            {
                timer.text = "0";
            }
        }


        if (stillTesting)
        {
            if (ao.active == true)
            {
                stillTesting = true;
                found++;
            }
            else
            {
                notFound++;
            }

        
            totalFrames++;
            


            foundText.text = found.ToString();
            notFoundText.text = notFound.ToString();
            totalFramesText.text = totalFrames.ToString();
            if (totalFrames > 0)
            {
                accuracy = (100f * found / totalFrames);
                accuracyText.text = System.Math.Round(accuracy,2).ToString() + '%';
            }
            return;
        }
    }


    public void StopTesting()
    {
        press_space_object.active = true;
        stillTesting = false;
        print(accuracy);
        ResetValues();

    }

    public void ResetValues()
    {
        accuracy = 0f;
        totalFrames = 0;
        found = 0;
        notFound = 0;
        time = testingTime;
        trackingTime = false;
    }

    public void StartTimer()
    {
        trackingTime = true;
    }
}

