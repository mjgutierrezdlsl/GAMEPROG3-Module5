using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class ConfigSettings : ScriptableObject
{
    /// <summary>
    /// Fires an event when the scriptable object has been loaded from JSON
    /// </summary>
    public event Action<ConfigSettings> JsonLoaded;

    /// <summary>
    /// Converts scriptable object to a JSON string
    /// </summary>
    /// <returns>JSON of the scriptable object</returns>
    public string ToJson() => JsonUtility.ToJson(this, true);

    /// <summary>
    /// Overwrites the values of the scriptable object with a JSON reference
    /// </summary>
    /// <param name="json">The JSON to load</param>
    public void FromJsonOverwrite(string json) => JsonUtility.FromJsonOverwrite(json, this);

    /// <summary>
    /// Writes JSON string to specified location
    /// </summary>
    /// <param name="path">The location to save the json file</param>
    /// <param name="fileName">The name which the file is saved</param>
    /// <remarks>Omit .json from the fileName as it is included in the method</remarks>
    public void WriteJsonToFile(string path, string fileName)
    {
        var json = ToJson();
        Debug.Log($"CONFIG SAVED:\n{json}");
        File.WriteAllText($"{path}/{fileName}.json", json);
        Debug.Log($"{fileName}.json saved to {path}");
    }

    /// <summary>
    /// Loads JSON from a specified location and updates the values of the scriptable object
    /// </summary>
    /// <param name="path">The location which the json file is saved</param>
    /// <param name="fileName">The name which the file is saved</param>
    /// <remarks>Omit .json from the fileName as it is included in the method</remarks>
    public void ReadFromJson(string path, string fileName)
    {
        var json = File.ReadAllText($"{path}/{fileName}.json");
        if (string.IsNullOrEmpty(json))
        {
            Debug.LogError($"{path}/{fileName}.json not found.");
            return;
        }
        Debug.Log($"CONFIG LOADED:\n{json}");
        FromJsonOverwrite(json);
        JsonLoaded?.Invoke(this);
    }
}
