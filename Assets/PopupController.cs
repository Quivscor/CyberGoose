using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField]
    private int popupCount;

    public GameObject popupPrefab;

    private List<GameObject> popups;
    public List<string> catchphrases;

    public List<GameObject> popupTracker;

    private void Start()
    {
        for(int i = 0; i < popupCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-2, 2), Random.Range(-3, 3));
            GameObject popup = GameObject.Instantiate<GameObject>(popupPrefab, position, Quaternion.identity, GameObject.Find("Canvas").gameObject.transform);
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
