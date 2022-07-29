using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class RankPayload
{
    public string name;
    public int score;

    public RankPayload(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

[System.Serializable]
public class RankData
{
    public int id;
    public string name;
    public int score;
    public string playTime;
}

[System.Serializable]
public class RankTable
{
    public List<RankData> table;
}

public class Rank : MonoBehaviour
{
    private readonly string API_HOST = "http://127.0.0.1:8080";
    public Director director;

    string GetUrl()
    {
        return API_HOST + "/api/rank";
    }

    UnityWebRequest GetRequest(string method)
    {
        UnityWebRequest request = new UnityWebRequest();
        request.SetRequestHeader("User-Agent", "RockScissorsPaper");

        if (method == UnityWebRequest.kHttpVerbGET)
        {
            request.SetRequestHeader("Accept", "application/json");
        }
        else if (method == UnityWebRequest.kHttpVerbPOST)
        {
            request.SetRequestHeader("Content-Type", "application/json");
        }

        request.url = GetUrl();
        request.method = method;

        request.downloadHandler = new DownloadHandlerBuffer();

        return request;
    }

    void CheckRequest(UnityWebRequest request)
    {
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Request Fail!");
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Request Success!");
        }
    }

    public IEnumerator Push()
    {
        byte[] payload = new System.Text.UTF8Encoding().GetBytes(
            JsonUtility.ToJson(new RankPayload(Director.Name, Director.Score))
        );

        UnityWebRequest request = GetRequest(UnityWebRequest.kHttpVerbPOST);
        request.uploadHandler = new UploadHandlerRaw(payload);

        yield return request.SendWebRequest();
        CheckRequest(request);

        request.Dispose();
    }

    public IEnumerator Pull()
    {
        UnityWebRequest request = GetRequest(UnityWebRequest.kHttpVerbGET);

        yield return request.SendWebRequest();
        CheckRequest(request);

        director.RankTable = JsonUtility.FromJson<RankTable>($"{{\"table\": {request.downloadHandler.text}}}").table;

        request.Dispose();
    }
}
