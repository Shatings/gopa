using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoLPlayer : MonoBehaviour
{
    public Transform my_tranform;
    public Transform tagert_tranform;

    private float speed = 500;
    private float axis = 0;

    private void GetMouseInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePos = Input.mousePosition;
            tagert_tranform.position = mousePos;
        }
    }
    private void MoveOb()
    {
        Vector3 mypos = my_tranform.position;
        Vector3 tarpos = tagert_tranform.position;
        tarpos.z = mypos.z;
        
        Vector3 vectorToTaget = tarpos - mypos;
        Vector3 qToTaget = Quaternion.Euler(0, 0, axis) * vectorToTaget;
        
        Quaternion tagetR=Quaternion.LookRotation(forward: Vector3.forward,upwards:qToTaget);
        my_tranform.rotation = Quaternion.RotateTowards(my_tranform.rotation, tagetR, speed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseInput();
        MoveOb();
    }
}
