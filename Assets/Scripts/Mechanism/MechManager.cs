using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechManager  {

    

    public static bool JudgePosition(Vector3[] positions,GameObject target)
    {
        foreach(Vector3 position in positions)
        {
            //Debug.Log((target.transform.position - position).magnitude);
            Debug.DrawLine(position, target.transform.position,Color.red);
            if ((target.transform.position - position).magnitude < 0.01f)
            {
                return true;
            }
            else
                continue;
        }
        return false;
    }


}
