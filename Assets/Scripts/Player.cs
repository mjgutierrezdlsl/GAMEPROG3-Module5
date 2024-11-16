using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] PlayerSettings _playerSettings;
    public List<Item> _inventory = new();
    private float _moveSpeed;
    private void OnEnable()
    {
        _playerSettings.JsonLoaded += OnJsonLoaded;
    }
    private void OnDisable()
    {
        _playerSettings.JsonLoaded -= OnJsonLoaded;
    }

    private void OnJsonLoaded(ConfigSettings settings)
    {
        var playerSettings = settings as PlayerSettings;
        _moveSpeed = playerSettings.MoveSpeed;
    }
    private void Start()
    {
        _moveSpeed = _playerSettings.MoveSpeed;
    }
    private void Update()
    {
        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}

[Serializable]
public class Item
{
    public string name;
    public int amount;
}