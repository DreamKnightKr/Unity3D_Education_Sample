import UnityEngine
import System.Collections

class GUIScript (MonoBehaviour):
	www as WWW = null;
	strLoadTypeName as string = "";
	
	def OnGUI() as void:
		fPosX as double = 20;
		fPosY as double = 50;
		fYInterval as double = 100;
		nYPosCount as int = 0;
		
		url as string;

		if GUI.Button(Rect(fPosX, fPosY + (fYInterval * nYPosCount), 400, 80), "Load SelectDirPath_Def"):
			strLoadTypeName = "SelectDirPath_Def";
			url = Application.streamingAssetsPath + AssetBundleHelperBoo.AssetbundleSubPath + "SelectDirPath_Def.assetbundle";
			if Application.platform != RuntimePlatform.Android:
				url = "file://" + url;
			Debug.Log ("Get from : " + url);

			www = WWW (url);
			StartCoroutine (LoadAsset ());

		nYPosCount++;
		if GUI.Button(Rect(fPosX, fPosY + (fYInterval * nYPosCount), 400, 80), "Load SelectDirPath_Def(Cached)"):
			strLoadTypeName = "SelectDirPath_Def";
			url = Application.streamingAssetsPath + AssetBundleHelperBoo.AssetbundleSubPath + "SelectDirPath_Def.assetbundle";
			if Application.platform != RuntimePlatform.Android:
					url = "file://" + url;
			Debug.Log ("Get from : " + url);

			www = WWW.LoadFromCacheOrDownload(url, 2014022501);
			StartCoroutine (LoadAsset ());
	
	def LoadAsset() as IEnumerator:
		while not www.isDone:
			Debug.Log("AssetLoading : " + www.progress);
			yield WaitForEndOfFrame();
			
		if null != www.error:
			Debug.LogError("Can't Load from StreamAsset!! \n" + www.error)
		else:
			if "SelectDirPath_Def" == strLoadTypeName:
				// Load GameObject(Prefab)
				prefab as GameObject = www.assetBundle.Load("Cube", typeof(GameObject)) as GameObject;
				GameObject.Instantiate( prefab );

				// Load TextAsset
				txt as TextAsset = www.assetBundle.Load("SampleText", typeof(TextAsset)) as TextAsset;
				Debug.Log(txt.text);
				
			Debug.Log("Load Done")

		yield null;
