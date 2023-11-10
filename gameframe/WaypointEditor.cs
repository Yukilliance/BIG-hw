using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
   Waypoint Waypoint => target as Waypoint;

    [System.Obsolete]
    private void OnSceneGUI()
   {  
      Handles.color = Color.red;
      for(int i=0;i<Waypoint.Points.Length;i++)
      {
        EditorGUI.BeginChangeCheck();


        //创建把手
        Vector3 currentWaypointPoint =Waypoint.CurrentPosition+Waypoint.Points[i];
        Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypointPoint,
           Quaternion.identity, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);
        
        //创建把手文字
        GUIStyle textstyle = new GUIStyle();
        textstyle.fontStyle = FontStyle.Bold;
        textstyle.fontSize = 16;
        textstyle.normal.textColor = Color.yellow;
        Vector3 textAlligment = Vector3.down*0.35f + Vector3.right*0.35f;
        Handles.Label(Waypoint.CurrentPosition+Waypoint.Points[i]+textAlligment,$"{i+1}",textstyle);

        EditorGUI.EndChangeCheck();

        if(EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target,"Free Move Handle");
            Waypoint.Points[i] = newWaypointPoint - Waypoint.CurrentPosition;
        }
      }
   }  
}
