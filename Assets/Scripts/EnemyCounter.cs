using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(50)]
public class EnemyCounter : MonoBehaviour
{

    private TextMeshProUGUI textBoxDisplay;
    
    private void Start()
    {
        textBoxDisplay = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        EnemyManager.Instance.OnEnemyCountChanged += OnEnemyCountChanged;
    }

    private void OnDisable()
    {
        EnemyManager.Instance.OnEnemyCountChanged -= OnEnemyCountChanged;
    }

    private void OnEnemyCountChanged(int newCount)
    {
        textBoxDisplay.text = "Enemies Alive: " + newCount;
    }
}
