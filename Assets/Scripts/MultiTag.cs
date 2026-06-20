using System.Collections.Generic;
using UnityEngine;

public class MultiTag : MonoBehaviour
{
    public enum MultiTags
    {
        Player,
        Enemy,
        NPC,
        Hurtbox
    }
    
    [SerializeField] private List<MultiTags> tags;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
