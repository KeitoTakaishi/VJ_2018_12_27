using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class HTTPSender : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.0.5:3000", "from-Unity");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            Debug.Log("Form upload complete!");
        }
    }
}