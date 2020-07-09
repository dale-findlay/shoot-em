using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the players phone's Gyroscope to rotate the camera in game. 
/// It also handles when the player is playing on a non gyroscope platform to use a FPS style camera movement.
/// </summary>
public class PlayerCamera : MonoBehaviour
{
    private Gyroscope gyroscope;
    private Quaternion rot;

    public bool enableCameraMove;

    private bool m_useGyro = false;
    public float mouseSensitivity = 10.0f;
    private float m_horizontalMouseMov;
    private float m_verticalMouseMov;

    public bool m_enabledFpsCamera = false;

    private void SetupVisonGyro()
    {
        m_useGyro = true;

        gyroscope = Input.gyro;
        gyroscope.enabled = true;
        transform.parent.rotation = Quaternion.Euler(90f, -90f, 0f);
        rot = new Quaternion(0, 0, 1, 0);
    }

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            SetupVisonGyro();
        }
    }

    /// <summary>
    /// Perform and update fps style camera rotation maths.
    /// </summary>
    void UpdateFPCameraRotation()
    {
        m_horizontalMouseMov += Input.GetAxis("Mouse X") * mouseSensitivity;
        m_verticalMouseMov -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        m_verticalMouseMov = Mathf.Clamp(m_verticalMouseMov, -80, 80);

        transform.localRotation = Quaternion.Euler(m_verticalMouseMov, m_horizontalMouseMov, 0);
    }

    void Update()
    {

        //This just allows me to more easily jump out of the game in the editor without the camera movement following me.
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_enabledFpsCamera = !m_enabledFpsCamera;
        }
#endif
        if (enableCameraMove)
        {
            if (m_useGyro)
            {
                transform.localRotation = gyroscope.attitude * rot;
            }
            else
            {
                UpdateFPCameraRotation();
            }
        }
    }
}
