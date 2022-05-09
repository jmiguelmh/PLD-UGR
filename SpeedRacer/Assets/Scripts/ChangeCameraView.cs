using System.Collections;
using UnityEngine;

public class ChangeCameraView : MonoBehaviour
{
    public GameObject defaultCamera;
    public GameObject farCamera;
    public GameObject firsPersonCamera;
    public int camMode;
    public string buttonName;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown(buttonName))
        {
            if (camMode == 3)
            {
                camMode = 0;
            }
            else
            {
                camMode++;
            }
            StartCoroutine(ModeChange());
        }
    }

    private IEnumerator ModeChange()
    {
        yield return new WaitForSeconds(0.01f);

        switch (camMode)
        {
            case 0:
                defaultCamera.SetActive(true);
                firsPersonCamera.SetActive(false);
                break;
            case 1:
                farCamera.SetActive(true);
                defaultCamera.SetActive(false);
                break;
            case 2:
                firsPersonCamera.SetActive(true);
                farCamera.SetActive(false);
                break;
        }
    }
}
