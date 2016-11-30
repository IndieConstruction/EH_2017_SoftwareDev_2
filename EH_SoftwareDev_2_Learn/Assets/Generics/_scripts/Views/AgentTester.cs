using UnityEngine;
using System.Collections;

public class AgentTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Agent<Agent1> A1 = new Agent<Agent1>();
        Agent<Agent2> A2 = new Agent<Agent2>();

        A1.DoSomething();
        A2.DoSomething();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
