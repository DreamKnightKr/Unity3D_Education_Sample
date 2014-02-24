using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour
{
	WWW www = null;
	string strLoadTypeName = "";
	// Use this for initialization
	void Start ()
	{

	}
        
	// Update is called once per frame
	void Update ()
	{
	}

	void OnGUI ()
	{
		float fPosX = 0, fPosY = 50, fYInterval = 100;
		int nYPosCount = 0;

		// Load From SteamingAssets
		nYPosCount++;
		if (GUI.Button (new Rect (fPosX, fPosY + (fYInterval * nYPosCount), 200, 80), "Load SelectDirPath_Def")) 
		{
			strLoadTypeName = "SelectDirPath_Def";
			string url = Application.streamingAssetsPath + AssetBundleHelper.AssetbundleSubPath + "SelectDirPath_Def.assetbundle";
			if (Application.platform != RuntimePlatform.Android)
					url = "file://" + url;
			Debug.Log ("Get from : " + url);

			www = new WWW (url);
			StartCoroutine (LoadAsset ());
		}
	}

	IEnumerator LoadAsset ()
	{
		while (!www.isDone) {
				yield return new WaitForSeconds (0.1f);
		}

		if (null != www.error)
				Debug.LogError ("Can't Load from StreamAsset!! \n" + www.error);
		else {
			if("SelectDirPath_Def" == strLoadTypeName)
			{
				// Load GameObject(Prefab)
				GameObject prefab = www.assetBundle.Load("Cube", typeof(GameObject)) as GameObject;
				GameObject.Instantiate( prefab );

				// Load TextAsset
				TextAsset txt = www.assetBundle.Load("SampleText", typeof(TextAsset)) as TextAsset;
				Debug.Log(txt.text);
			}
			Debug.Log ("Load Done");
		}

		yield return null;
	}
}
