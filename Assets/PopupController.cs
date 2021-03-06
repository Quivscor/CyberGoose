﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField]
    private int popupCount;
    public GameObject canvasReference;

    public GameObject popupPrefab;

    private List<GameObject> popups;
    public List<string> catchphrases;

    public List<GameObject> popupTracker;

    private void Start()
    {
        for(int i = 0; i < popupCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-1.5f, 1.0f), Random.Range(-3.0f, 0f));
            GameObject popup = GameObject.Instantiate<GameObject>(popupPrefab, position, Quaternion.identity);
            popup.transform.SetParent(canvasReference.transform, false);
            popup.transform.position = position;
            popup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = catchphrases[Random.Range(0, catchphrases.Count)];
            popupTracker.Add(popup);
        }
    }

    private void FixedUpdate()
    {
        popupTracker.RemoveAll(x => x == null);
        if (popupTracker.Count == 0)
            GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnWin();
    }
}
