using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// 改变球体颜色
public class FadeColor3 : MonoBehaviour
{
    private Material deMaterial;     //默认材质
    public float speed = 10f;        //渐变速度
    public float rotateSpeed = 360f; //旋转速度
    void Start()
    {
        deMaterial = GetComponent<MeshRenderer>().material;
        InvokeRepeating("ChangeColor", 0, 1);
        //time是几秒钟以后开始执行methodName函数，repeatRate是指每隔几秒执行一次
        //InvokeRepeating(string methodName,  float time,  float repeatRate):
    }
    //随机颜色
    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color color = new Color(r, g, b);
        return color;
    }
    //改变颜色
    private void ChangeColor()
    {
        StopAllCoroutines();
        Color temColor = RandomColor();
        StartCoroutine(ColorEnumerator(temColor));
    }
    //开启协程——循环颜色
    IEnumerator ColorEnumerator(Color temColor)
    {
        while (true) //死循环
        {
            deMaterial.color = Color.Lerp(deMaterial.color, temColor, speed * Time.deltaTime); //插值
            yield return 10;                                                                   //每次暂停10帧
        }
    }
}
