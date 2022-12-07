using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class ScenePreload 
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.tea");
        if (!File.Exists(path))
        {
            Debug.Log("Save file does not exist! Creating empty file...");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData();

            formatter.Serialize(stream, data);
            stream.Close();
        }
        else
        {
            Debug.Log("Save file found succesfully...");
        }

        Application.targetFrameRate = 60;
    }
}
