using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour
{
    public GameObject objTextHello_Window;
    public GameObject objTextHello_iOS;
    public GameObject objTextHello_Android;

    static bool isLoaded = false;

    // Use this for initialization
    void Start()
    {

        if (!isLoaded)
        {
            DontDestroyOnLoad(gameObject);

            // 다시 Scene1로 돌아 올 떄 중복 생성 방지. 보통은 싱글턴이라든가 초기화 Scene이 라든가 조금더 복잡하고 우아한 방식 사용.
            isLoaded = true;
        } else
            Destroy(gameObject);
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
