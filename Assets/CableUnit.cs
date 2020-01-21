using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CableUnit : MonoBehaviour
{
    private static CableConnector connector;

    public Sprite line;
    public Sprite curve;
    public Sprite T;

    private Image image;
    private Button button;
    public float rotationRate = 1000;

    public int ID;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        if (connector == null)
            connector = GetComponentInParent<CableConnector>();
    }

    /// <summary>
    /// Cases:
    /// 0 - horizontal bar
    /// 1 - vertical bar
    /// 2 - left-down curve
    /// 3 - left-up curve
    /// 4 - right-up curve
    /// 5 - right-down curve
    /// 6 - down-horizontal T
    /// 7 - left-vertical T
    /// 8 - right-vertical T
    /// 9 - up-horizontal T
    /// </summary>
    /// <param name="variant"></param>
    public void SetStartConnections(int variant)
    {
        switch(variant)
        {
            case 0: //horizontal bar
                image.sprite = line;
                left = true;
                right = true;
                up = false;
                down = false;
                break;
            case 1: //vertical bar
                image.sprite = line;
                RotatePicInstant();
                up = true;
                down = true;
                left = false;
                right = false;
                break;
            case 2: //left-down curve
                image.sprite = curve;
                left = true;
                down = true;
                up = false;
                right = false;
                break;
            case 3: //left-up curve
                image.sprite = curve;
                RotatePicInstant();
                left = true;
                up = true;
                down = false;
                right = false;
                break;
            case 4: //right-up curve
                image.sprite = curve;
                RotatePicInstant();
                RotatePicInstant();
                up = true;
                right = true;
                left = false;
                down = false;
                break;
            case 5: //right-down curve
                image.sprite = curve;
                RotatePicInstant();
                RotatePicInstant();
                RotatePicInstant();
                right = true;
                down = true;
                left = false;
                up = false;
                break;
            case 6: //down-horizontal T
                image.sprite = T;
                RotatePicInstant();
                RotatePicInstant();
                down = true;
                left = true;
                right = true;
                up = false;
                break;
            case 7: //left-vertical T
                image.sprite = T;
                RotatePicInstant();
                RotatePicInstant();
                RotatePicInstant();
                left = true;
                up = true;
                down = true;
                right = false;
                break;
            case 8: //right-vertical T
                image.sprite = T;
                RotatePicInstant();
                right = true;
                up = true;
                down = true;
                left = false;
                break;
            case 9: //up-horizontal T
                image.sprite = T;
                up = true;
                right = true;
                left = true;
                down = false;
                break;
        }
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

    private void RotatePicInstant()
    {
        image.rectTransform.Rotate(0, 0, -90.0f);
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
