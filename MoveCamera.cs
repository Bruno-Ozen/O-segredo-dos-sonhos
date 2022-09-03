using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Camera cameragame;
    MoveSofia sofiaObjeto;
    void Start()
    {
        sofiaObjeto = GetComponent<MoveSofia>();
    }

    // Update is called once per frame
    void Update()
    {
        cameragame.transform.position = new Vector3(sofiaObjeto.sofiaBody.transform.position.x, cameragame.transform.position.y, cameragame.transform.position.z);
    }
}
