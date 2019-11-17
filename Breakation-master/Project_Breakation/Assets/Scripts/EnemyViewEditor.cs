using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof (EnemySight))]
public class EnemyViewEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemySight es = (EnemySight)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(es.transform.position, Vector3.up, Vector3.forward, 360, es.viewRadius);

        Vector3 viewAngleA = es.DirFromAngle(-es.viewAngle / 2, false);
        Vector3 viewAngleB = es.DirFromAngle(es.viewAngle / 2, false);

        Handles.DrawLine(es.transform.position, es.transform.position + viewAngleA * es.viewRadius);
        Handles.DrawLine(es.transform.position, es.transform.position + viewAngleB * es.viewRadius);


        Handles.color = Color.red;
        foreach(Transform visibleTargets in es.visibleTargets)
        {
            Handles.DrawLine(es.transform.position, visibleTargets.position);
        }
    }
}
