using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour
{
    public GameObject objTextHello_Window;
    public GameObject objTextHello_iOS;
    public GameObject objTextHello_Android;

    // Use this for initialization
    void Start()
    {
    }
                
    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        float fPosX = 250, fPosY = 50, fYInterval = 40;
        int nYPosCount = 0;

        if (GUI.Button(new Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "Show Hello ~"))
        {
            #if UNITY_IPHONE
            GameObject.Instantiate( objTextHello_iOS );
            #elif UNITY_ANDROID
            GameObject.Instantiate( objTextHello_Android );
            #else
            GameObject.Instantiate( objTextHello_Window );
            #endif
        }
    }
}
