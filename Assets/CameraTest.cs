using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    CinemachineImpulseSource impulseSource;
    void Start()
    {
        impulseSource = GetComponentInChildren<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            impulseSource.GenerateImpulse(0.2f);
        }
    }
}
