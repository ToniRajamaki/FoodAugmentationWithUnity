using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccuracyCalc : MonoBehaviour
{

    [SerializeField] GameObject ao;
    int found;
    int totalFrames;
    float accuracy;
    [SerializeField] int testingTime;
    bool stillTesting;

    [SerializeField] GameObject framesObject;
    TextMeshProUGUI totalFramesText;

    [SerializeField] GameObject foundObject;
    TextMeshProUGUI foundText;

    [SerializeField] GameObject accuracyObject;
    TextMeshProUGUI accuracyText;
    // Start is called before the first frame update
    void Start()
    {
        stillTesting = false;
        totalFramesText = framesObject.GetComponent<TextMeshProUGUI>();
        foundText = foundObject.GetComponent<TextMeshProUGUI>();
        accuracyText = accuracyObject.GetComponent<TextMeshProUGUI>();
        found = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            stillTesting = true;
            Invoke("StopTesting", testingTime);
        }


        if (stillTesting)
        {
            if (ao.active == true)
            {
                stillTesting = true;
                found++;
            }

            if (found > 0)
            {
                totalFrames++;
            }


            foundText.text = found.ToString();
            totalFramesText.text = totalFrames.ToString();
            if (totalFrames > 0)
            {
                accuracy = (100f * found / totalFrames);
                accuracyText.text = accuracy.ToString() + '%';
            }
            return;
        }
    }


    public void StopTesting()
    {
        stillTesting = false;
        print(accuracy);
    }
}

