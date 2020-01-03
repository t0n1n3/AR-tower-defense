using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject goob;
    // Start is called before the first frame update
    void Start () {
        InvokeRepeating ("Spawn", 0, 3f);
    }

    // Update is called once per frame
    void Update () {

    }

    void Spawn () {
        Instantiate (goob, this.transform.position, this.transform.rotation);
    }

}