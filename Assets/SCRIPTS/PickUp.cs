using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

public class PickUp : MonoBehaviour
{
    GameObject startTrans;
    Transform controller;
    bool pickedUp = false;
    char hand;

    public Quaternion RotationOffset;
    public Vector3 tempVec;

    // Start is called before the first frame update
    void Start()
    {
        startTrans = new GameObject();

        startTrans.transform.position = transform.position;
        startTrans.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
       if (hand == 'R')
        {
            if (OpenXRInput.)
        }
    }
}
