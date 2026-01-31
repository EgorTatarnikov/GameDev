using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private Text text2;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "muteIsOn " + PlayerPrefs.GetInt("muteIsOn");
    }

    // Update is called once per frame
    void Update()
    {
        text2.text = "muteIsOn " + PlayerPrefs.GetInt("muteIsOn");
    }
}
