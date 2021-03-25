using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyCalc : MonoBehaviour
{

    [SerializeField] GameObject ao;
    int found;
    int totalFrames;
    // Start is called before the first frame update
    void Start()
    {
        found = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ao.active == true)
        {
            found++;
        }

        if (found > 0)
        {
            totalFrames++;
        }

        if(totalFrames%50 == 0)
        {
            print("found:"+found);
            print("total frames:" + totalFrames);
        }
    }
}
