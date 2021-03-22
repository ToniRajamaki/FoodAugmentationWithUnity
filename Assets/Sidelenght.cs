using ArucoUnity.Objects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sidelenght : MonoBehaviour
{
    [SerializeField] GameObject MarkerObject;
    ArucoObject ao;
    string value;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        ao = MarkerObject.GetComponent<ArucoObject>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        value = MarkerObject.GetComponent<ArucoMarker>().MarkerSideLength.ToString();
         text.text = value;
    }
}
