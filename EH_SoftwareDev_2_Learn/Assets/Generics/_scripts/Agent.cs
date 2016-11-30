using UnityEngine;
using System.Collections;

public class Agent<T> where T : IAgent  {

    T MyVar;

    public Agent (){
        
    }

    public void DoSomething() {
        Debug.Log(MyVar.GetName());
    }

}
