using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/New Player Settings")]
public class PlayerSettings : ConfigSettings
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
    [field: SerializeField] public Item[] Inventory { get; private set; }
    [field: SerializeField] public Color Color { get; private set; } = Color.red;

}
