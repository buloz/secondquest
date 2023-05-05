using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LeveManager", menuName = "ScriptableObjects/Manager/LevelManager")]
public class LevelManager : ScriptableObject
{

    public GameState GameState { get; set; }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
