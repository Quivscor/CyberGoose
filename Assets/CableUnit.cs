using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CableUnit : MonoBehaviour
{
    private static CableConnector connector;

    private Image image;
    private Button button;
    public float rotationRate = 1000;

    public int ID;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        if (connector == null)
            connector = GetComponentInParent<CableConnector>();
    }

    public void RotateCable()
    {
        RotateImage();
        RotateConnections();
    }

    private void RotateImage()
    {
        StartCoroutine("RotatePicOverTimeAndLockButton");
    }

    private IEnumerator RotatePicOverTimeAndLockButton()
    {
        float rotation = 90.0f;
        button.interactable = false;
        while(rotation > 0)
        {
            image.rectTransform.Rotate(0, 0, -Time.deltaTime * rotationRate);
            Debug.Log(-Time.deltaTime * rotationRate);
            rotation -= Time.deltaTime * rotationRate;
            yield return new WaitForEndOfFrame();
        }
        button.interactable = true;

        connector.CheckWinCondition();
    }

    private void RotateConnections()
    {
        bool tempUp, tempDown, tempLeft, tempRight;
        tempUp = tempDown = tempLeft = tempRight = false;

        if (up)
            tempRight = true;
        if (right)
            tempDown = true;
        if (down)
            tempLeft = true;
        if (left)
            tempUp = true;

        up = tempUp;
        down = tempDown;
        left = tempLeft;
        right = tempRight;
    }
}
