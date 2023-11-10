using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]private Vector3[] points;

    public Vector3[] Points => points;
    private Vector3 CurrentFatherPosition;//整个路径系父物体坐标

    public Vector3 CurrentPosition => CurrentFatherPosition;
    private bool gameStarted=false;



    // Start is called before the first frame update
    void Start()
    {
        gameStarted=true;
        CurrentFatherPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if(!gameStarted && transform.hasChanged)
        {
            CurrentFatherPosition = transform.position;
        }


        for(int i=0;i<points.Length;i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(points[i]+CurrentFatherPosition,0.5f);//生成路径点

            if(i<points.Length-1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i]+CurrentFatherPosition,points[i+1]+CurrentFatherPosition);//路径点连线
            }
        }
    }
}
