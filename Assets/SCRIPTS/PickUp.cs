using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit.Attachment;
using UnityEngine.XR.Interaction.Toolkit.Gaze;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;


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
       

    }
}
