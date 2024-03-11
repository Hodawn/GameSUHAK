using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGMath : MonoBehaviour
{
    


    //±æÀÌ
    public static float Magnitude(Vector3 a)
    {
        //return Mathf.Sqrt(a.magnitude);

        var x = Mathf.Pow(a.x, 2);
        var y = Mathf.Pow(a.y, 2);
        var z = Mathf.Pow(a.z, 2);

        return Mathf.Sqrt(px + py + pz);
    }
    //´ÜÀ§ º¤ÅÍ
    public static Vector3 Normalize(Vector3 a)
    {
        //var normal = a.normalized;
        var magnitude = Magnitude(a);
        return new Vector3(a.x / magnitude, a.y / magnitude, a.z / magnitude);
    }
    //µ¡¼À
    public static Vector3 Add(Vector3 a, Vector3 b)
    {
        //return a + b;
        return new Vector3(a.x + b.x + a.y + b.y, a.z + b.z);
    }
    //»¬¼À
    public static Vector3 Subtract(Vector3 a, float scalar)
    {
        //return.a-b;
        return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }
    

    //½ºÄ®¶ó°ö
    public static Vector3 Scale(Vector3 a, float scalar)
    {
        //return a *scalar;
        return new Vector3(a.x * scalar, a.y * scalar, a.z * scalar);
    }

    //³»Àû
    public static Vector3 Dot(Vector3 a, Vector3 b)
    {
        //return Vetor3.Dot(a, b);
        var top = a.x * b.x + a.y * b.y + a.z * b.z;

        var px = Mathf.Pow(a.x, 2);
        var py = Mathf.Pow(a.y, 2);
        var pz = Mathf.Pow(a.z, 2);

        var qx = Mathf.Pow(a.x, 2);
        var qy = Mathf.Pow(a.y, 2);
        var qz = Mathf.Pow(a.z, 2);

        var bottom = Mathf.Sqrt(px + py + pz) * Mathf.Sqrt(qx + qy + qz);

        return Mathf.Acos(top / bottom);
    }
    //¿ÜÀû
    public static Vector3 Cross(Vector3 a, Vector3 b)
    {

        var px = a.y * b.z - a.z * b.y;
        var py = a.y * b.z - a.z * b.y;
        var pz = a.y * b.z - a.z * b.y;

        return new Vector3(px, py, pz);
    }

    //¶óµð¾È º¯È¯
    public static float DegreeToRafian(float degree)
    {
        return degree * (360 / Mathf.PI * 2);
    }
    //µð±×¸® º¯È¯
    public static float RadianTodegree(float radian)
    {
       
        return radian * (360 / Mathf.PI * 2);
    }


}
