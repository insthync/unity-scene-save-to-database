using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SaveObjectData
{
    public int id;
    public string prefabId;
    public EContentType contentType;
    public string content;
    public float posX;
    public float posY;
    public float posZ;
    public float rotX;
    public float rotY;
    public float rotZ;
    public float scaleX;
    public float scaleY;
    public float scaleZ;
}

[System.Serializable]
public struct SaveContent
{
    public List<SaveObjectData> objects;
}