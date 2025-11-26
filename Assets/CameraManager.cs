using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : SceneSingletonManager<CameraManager>
{
    CinemachineVirtualCamera virtualCamera;
    CinemachineComposer composer;
    CinemachineImpulseSource impulseSource;

    protected override void Init()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        composer = virtualCamera.GetCinemachineComponent<CinemachineComposer>();
        impulseSource = GetComponentInChildren<CinemachineImpulseSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetBottomUIAim();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetDefaultAim();
        }
    }

    public void SetBottomUIAim()
    {
        composer.m_ScreenY = 0.35f;
    }

    public void SetDefaultAim()
    {
        composer.m_ScreenY = 0.5f;
    }
    
    public void ShakeCamera(float force=0.2f)
    {
        impulseSource.GenerateImpulse(force);
    }
}
