import UnityEngine
import System.Collections

class GUIScript (MonoBehaviour):
	public Dummy as GameObject
	/*
	public objTextHello_Window as GameObject
	public objTextHello_iOS as GameObject
	public objTextHello_Android as GameObject

	txt as TextMesh = null
	www as WWW = null

	def Start ():
		pass

	def Update ():
		pass

	def OnGUI() as void:
		fPosX as double = 250
		fPosY as double = 50
		fYInterval as double = 40
		nYPosCount as int = 0

		if GUI.Button(Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "Show Hello ~"):
			// !! Boo currently supports only the ifdef directive. 
			// [Unity Doc URL]
			//	https://docs.unity3d.com/Documentation/Manual/PlatformDependentCompilation.html
			ifdef UNITY_IPHONE :
				GameObject.Instantiate( objTextHello_iOS )
			ifdef UNITY_ANDROID :
				GameObject.Instantiate( objTextHello_Android )
			ifdef UNITY_STANDALONE_OSX:
				GameObject.Instantiate( objTextHello_Window )

		// Load From Resource
		nYPosCount++
		if GUI.Button(Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "(1)Show Resources"):
			if null == txt :  //  중복 생성 막자...
				txt = (GameObject.Instantiate( Resources.Load("Prefabs/text") ) as GameObject).GetComponent("TextMesh") as TextMesh

			//textRes as object = Resources.Load("SampleText")
			textRes as object = Resources.Load("SampleTextCSV")
			//textRes as object = Resources.Load("SampleTextXML")
			if textRes isa TextAsset :
				str as TextAsset = textRes as TextAsset
				txt.text = str.text
			else :
				Debug.LogError("Can't find Text Type Asset")

		// Load From SteamingAssets
		nYPosCount++;
		if GUI.Button(Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "(2)Show StreamingAssets"):
			if null == txt:
				Debug.LogError ("Press '(1)Show Resources' Button")
			url as string = Application.streamingAssetsPath + "/TestPage.html"
			if Application.platform != RuntimePlatform.Android:
				url = "file://" + url
			Debug.Log("Get from : " + url)
			
			// 자세한 구현 내용은 "Coroutine, 추가 다운로드 Step에 ..."
			// 중요한건 Resource Folder 보다 복잡하다는 것.. 즉시성이 없다는 것.
			www = WWW(url);
			StartCoroutine(LoadAsset())
	
	def LoadAsset() as IEnumerator:
		while not www.isDone:
			yield WaitForSeconds(0.1f)
			
		if null != www.error:
			Debug.LogError("Can't Load from StreamAsset!! \n" + www.error)
		else:
			// Byte Stream -> String
			txt.text = System.Text.Encoding.UTF8.GetString(www.bytes)
			Debug.Log("Load Done")

		yield null
		*/
