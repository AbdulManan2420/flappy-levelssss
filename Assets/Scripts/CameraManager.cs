using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera frontCamera;
    public Camera sideCamera;

    private bool isFront = true;

    void Start()
    {
        frontCamera.gameObject.SetActive(true);
        sideCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isFront = !isFront;

            frontCamera.gameObject.SetActive(isFront);
            sideCamera.gameObject.SetActive(!isFront);
        }
    }
}