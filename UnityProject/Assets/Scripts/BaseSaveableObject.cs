using UnityEngine;

public abstract class BaseSaveableObject : MonoBehaviour
{
    public abstract EContentType ContentType { get; }
    [HideInInspector]
    public int id;
    public string prefabId;
    public string content;

    public abstract string GetContent();

    public SaveObjectData Save()
    {
        var saveData = new SaveObjectData()
        {
            id = id,
            prefabId = prefabId,
            contentType = ContentType,
            content = GetContent(),
            posX = transform.position.x,
            posY = transform.position.y,
            posZ = transform.position.z,
            rotX = transform.eulerAngles.x,
            rotY = transform.eulerAngles.x,
            rotZ = transform.eulerAngles.x,
            scaleX = transform.localScale.x,
            scaleY = transform.localScale.y,
            scaleZ = transform.localScale.z,
        };
        return saveData;
    }
}
