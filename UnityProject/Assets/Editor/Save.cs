using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Networking;

public class Save
{
    [MenuItem("Sample Scene Save/Save")]
    static async void SaveMenu()
    {
        var objects = Object.FindObjectsOfType<BaseSaveableObject>();
        var list = new List<SaveObjectData>();
        foreach (var obj in objects)
        {
            list.Add(obj.Save());
        }
        string content = JsonUtility.ToJson(new SaveContent()
        {
            objects = list,
        });
        var request = new UnityWebRequest("http://localhost/unity-scene-save-to-database", "POST");
        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(content.ToCharArray()));
        request.uploadHandler.contentType = "application/json";
        request.downloadHandler = new DownloadHandlerBuffer();
        var op = request.SendWebRequest();
        while (!op.isDone)
        {
            await Task.Yield();
        }
        Debug.Log(request.downloadHandler.text);
    }

    [MenuItem("Sample Scene Save/Load")]
    static async void LoadMenu()
    {
        var request = new UnityWebRequest("http://localhost/unity-scene-save-to-database");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();
        var op = request.SendWebRequest();
        while (!op.isDone)
        {
            await Task.Yield();
        }

    }
}