using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base per ogni stato della macchina a stati.
/// </summary>
public abstract class State {

    public abstract void Start();
    public abstract void Update();
    public abstract void End();
}
