using System.Collections.Generic;
using UnityEngine;

public class CharacterFlags : MonoBehaviour
{
    [SerializeField] private List<EnumCharacterFlags> flags = new List<EnumCharacterFlags>();
    private Dictionary<EnumCharacterFlags, bool> flagsDict = new Dictionary<EnumCharacterFlags, bool>();

    public void Initialize()
    {
        foreach(EnumCharacterFlags flag in flags) { flagsDict.Add(flag, false); }
    }
    
    public bool GetFlag(EnumCharacterFlags flag)
    {
        if(flagsDict.ContainsKey(flag)) return flagsDict[flag];
        return false;
    }

    public bool SetFlag(EnumCharacterFlags flag, bool value)
    {
        if (flagsDict.ContainsKey(flag))
        {
            flagsDict[flag] = value;
            return true;
        }
        return false;
    }
}
