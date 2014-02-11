using UnityEngine;
using System.Collections;

public class TextVisibleControl : MonoBehaviour {
    public GameObject objText_Editor;
    public GameObject objText_Window;
    public GameObject objText_iOS;
    public GameObject objText_Android;


	// Use this for initialization
	void Start () {
        if(Application.isEditor)
        {
            objText_Editor.SetActive(true);
        }

        {
            switch(Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                    objText_Window.SetActive(true); // Will Show On exe Build
                    break;
                case RuntimePlatform.IPhonePlayer:
                    objText_iOS.SetActive(true);    // Will Show On iOS Devices
                    break;
                case RuntimePlatform.Android:
                    objText_Android.SetActive(true);    // Will Show On Android devices
                    break;
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
