using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIjoysticks : MonoBehaviour
{

    //虚拟方向按钮初始位置
    public Vector3 initPosition;
    //虚拟方向按钮可移动的半径
    public float r;
    //border对象
    public Transform border;
    void Start()
    {
        //获取border对象的transform组件
        border = GameObject.Find("border").transform;
        initPosition = GetComponentInParent<RectTransform>().position;
        r = Vector3.Distance(transform.position, border.position);

    }

    private float horizontal = 0;
    private float vertical = 0;

    public float Horizontal
    {
        get { return horizontal; }
    }

    public float Vertical
    {
        get { return vertical; }
    }
    public Vector3 Direction()
    {
        Vector3 direction = new Vector3(horizontal, 0 , vertical);
        Debug.Log(direction);
        return direction;
    }
    void Update()
    {
        horizontal = transform.localPosition.x;
        vertical = transform.localPosition.y;
    }
        public void OnDragIng()
    {

        if (Input.touchCount == 1)
            //如果鼠标到虚拟键盘原点的位置 < 半径r
            if (Vector3.Distance(Input.mousePosition, initPosition) < r)
        {
            //虚拟键跟随鼠标
            transform.position = Input.mousePosition;
        }
        else
        {
            //计算出鼠标和原点之间的向量
            Vector3 dir = Input.mousePosition - initPosition;
            //这里dir.normalized是向量归一化的意思，实在不理解你可以理解成这就是一个方向，就是原点到鼠标的方向，乘以半径你可以理解成在原点到鼠标的方向上加上半径的距离
            transform.position = initPosition + dir.normalized * r;
        }
    }
    //鼠标松开
    public void OnDragEnd()
    {
        //松开鼠标虚拟摇杆回到原点
        transform.position = initPosition;
    }
}
