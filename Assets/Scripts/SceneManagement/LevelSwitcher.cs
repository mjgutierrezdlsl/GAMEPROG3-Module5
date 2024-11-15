using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private string[] additiveLevels;
    [SerializeField] private string[] unloadedLevels;

    public void SwitchLevel(string levelName)
    {
        LevelManager.Instance.LoadScene(levelName);
    }

    public void SwitchLevelAdditive()
    {
        LevelManager.Instance.LoadScenesAdditive(additiveLevels, unloadedLevels);
    }
}