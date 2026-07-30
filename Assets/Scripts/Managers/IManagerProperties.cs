using UnityEngine;

public interface IManagerProperties
{
    public bool IsLoaded { get; }

    public void SetInstance();
}
