using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] ConfigSettings[] _configurations;
    [SerializeField] DataPath _saveLocation;
    public string SaveLocation => _saveLocation switch
    {
        DataPath.NonPersistent => Application.dataPath,
        DataPath.Persistent => Application.persistentDataPath,
        DataPath.StreamingAssets => Application.streamingAssetsPath,
        _ => null,

    };
    public void SaveConfigurations()
    {
        foreach (var config in _configurations)
        {
            config.WriteJsonToFile(SaveLocation, config.name);
        }
    }
    public void LoadConfigurations()
    {
        foreach (var config in _configurations)
        {
            config.ReadFromJson(SaveLocation, config.name);
        }
    }
}

public enum DataPath
{
    NonPersistent, Persistent, StreamingAssets
}