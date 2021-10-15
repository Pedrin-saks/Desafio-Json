using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ServiceAPI : MonoBehaviour
{
    public string requestResult;
    public JsonDate jsonDate;
    public bool isSucess;


    public IEnumerator GetInfoReturn(string name, string email, string birthdate)
    {
        string[] firstName = name.Split(' ');
        string url = "https://sweetbonus.com.br/sweet-juice/trainee-test/submit?candidate=" + firstName[0].ToUpper() + "&fullname="+ name +
            "&email=" + email + "&birthdate=" + birthdate;

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            requestResult = "Erro de conexão: " + www.error;
            Debug.Log(requestResult);
            isSucess = false; 
        }
        else
        {
            string jsonDownloaded = www.downloadHandler.text;
            jsonDate = JsonUtility.FromJson<JsonDate>(jsonDownloaded);
            isSucess = true;
        }
    }
}
