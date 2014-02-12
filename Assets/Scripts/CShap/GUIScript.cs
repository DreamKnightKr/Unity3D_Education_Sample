using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour
{
    public GameObject objTextHello_Window;
    public GameObject objTextHello_iOS;
    public GameObject objTextHello_Android;

    TextMesh txt = null;
    WWW www = null;

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

        // Load From Resource
        nYPosCount++;
        if (GUI.Button(new Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "Show Resources"))
        {
            if(null == txt)  //  중복 생성 막자...
                txt = ((GameObject)GameObject.Instantiate( Resources.Load("Prefabs/text"))).GetComponent<TextMesh>();

            //object textRes = Resources.Load("SampleText");
            object textRes = Resources.Load("SampleTextCSV");
            //object textRes = Resources.Load("SampleTextXML");
            if(textRes is TextAsset)
            {
                TextAsset str = textRes as TextAsset;
                txt.text = str.text;
            }
            else
                Debug.LogError("Can't find Text Type Asset");
        }

        // Load From SteamingAssets
        nYPosCount++;
        if (GUI.Button(new Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "Show StreamingAssets"))
        {
            string url = Application.streamingAssetsPath + "/TestPage.html";
            if(Application.platform != RuntimePlatform.Android)
                url = "file://" + url;
            Debug.Log("Get from : " + url);

            // 자세한 구현 내용은 "Corutine, 추가 다운로드 Step에 ..."
            // 중요한건 Resource Folder 보다 복잡하다는 것.. 즉시성이 없다는 것.
            www = new WWW(url);
            StartCoroutine(LoadAsset());
        }
    }

    IEnumerator LoadAsset()
    {
        while(!www.isDone)
        {
            yield return new WaitForSeconds(0.1f);
        }

        if(null != www.error)
            Debug.LogError("Can't Load from StreamAsset!! \n" + www.error);
        else
        {
            // Byte Stream -> String
            txt.text = System.Text.Encoding.UTF8.GetString(www.bytes);
            Debug.Log("Load Done");
        }

        yield return null;
    }
}
