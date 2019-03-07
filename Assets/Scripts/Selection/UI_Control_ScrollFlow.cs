using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UI_Control_ScrollFlow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public RectTransform Rect;
    public List<UI_Control_ScrollFlow_Item> Items;
    /// <summary>
    /// 宽度
    /// </summary>
    public float Width=500;
    /// <summary>
    /// 大小
    /// </summary>
    public float MaxScale=1;
    /// <summary>
    /// StartValue开始坐标值，AddValue间隔坐标值，小于vmian 达到最左，大于vmax达到最右
    /// </summary>
    public float StartValue = 0.1f, AddValue = 0.2f, VMin = 0.1f, VMax = 0.9f;
    /// <summary>
    /// 坐标曲线
    /// </summary>
    public AnimationCurve PositionCurve;
    /// <summary>
    /// 大小曲线
    /// </summary>
    public AnimationCurve ScaleCurve;
    /// <summary>
    /// 透明曲线
    /// </summary>
    public AnimationCurve ApaCurve;
    /// <summary>
    /// 计算值
    /// </summary>
    private Vector2 start_point, add_vect;
    /// <summary>
    /// 动画状态
    /// </summary>
    public bool _anim = false;
    /// <summary>
    /// 动画速度
    /// </summary>
    public float _anim_speed = 1f;

    private float v = 0;
    private List<UI_Control_ScrollFlow_Item> GotoFirstItems = new List<UI_Control_ScrollFlow_Item>(), GotoLaserItems = new List<UI_Control_ScrollFlow_Item>();
    public event CallBack<UI_Control_ScrollFlow_Item> MoveEnd;
    public void Refresh()
    {
        for (int i = 0; i < Rect.childCount; i++)
        {
            Transform tran = Rect.GetChild(i);
            UI_Control_ScrollFlow_Item item = tran.GetComponent<UI_Control_ScrollFlow_Item>();
            if (item != null)
            {

                item.transform.GetChild(0).GetComponent<Text>().text = i.ToString();

                Items.Add(item);
                item.Init(this);
                item.Drag(StartValue + i * AddValue);
                if (item.v - 0.5 < 0.05f)
                {
                    Current = Items[i];
                }
            }
        }
        if (Rect.childCount < 5)
        {
            VMax = StartValue + 4 * AddValue;
        }
        else
        {
            VMax = StartValue + (Rect.childCount - 1) * AddValue;
        }
        if (MoveEnd!=null)
        {
            MoveEnd(Current);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        start_point = eventData.position;
        add_vect = Vector3.zero;
        _anim = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        add_vect = eventData.position - start_point;
        v = eventData.delta.x * 1.00f / Width;
        for (int i = 0; i < Items.Count; i++)
        {
            Items[i].Drag(v);
        }
        Check(v);
    }
    
    public void OnClick()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //add_vect = eventData.position - start_point;
            v = 1;
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Drag(v);
            }
            Check(v);
        } 
        else if(Input.GetKeyDown(KeyCode.A))
        {
            //add_vect = eventData.position - start_point;
            v = -1;
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Drag(v);
            }
            Check(v);
        }
    }

    public void Check(float _v)
    {
        if (_v < 0)
        {//向左运动
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].v < (VMin - AddValue / 2))
                {
                    GotoLaserItems.Add(Items[i]);
                }
            }
            if (GotoLaserItems.Count > 0)
            {
                for (int i = 0; i < GotoLaserItems.Count; i++)
                {
                    GotoLaserItems[i].v = Items[Items.Count - 1].v + AddValue;
                    Items.Remove(GotoLaserItems[i]);
                    Items.Add(GotoLaserItems[i]);
                }
                GotoLaserItems.Clear();
            }
        }
        else if (_v > 0)
        {//向右运动，需要把右边的放到前面来

            for (int i = Items.Count-1; i >0; i--)
            {
                if (Items[i].v >= VMax)
                {
                    GotoFirstItems.Add(Items[i]);
                }
            }
            if (GotoFirstItems.Count > 0)
            {
                for (int i = 0; i < GotoFirstItems.Count; i++)
                {
                    GotoFirstItems[i].v = Items[0].v - AddValue;
                    Items.Remove(GotoFirstItems[i]);
                    Items.Insert(0, GotoFirstItems[i]);
                }
                GotoFirstItems.Clear();
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float k = 0,v1;
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].v >= VMin)
            {
                v1 = (Items[i].v - VMin)%AddValue;
                //Debug.Log(v1 + "--" + NextAddValue);
                if (add_vect.x >= 0)
                {
                    k = AddValue - v1;
                }
                else
                {
                    k = v1 * -1;
                }
                break;
            }
        }
        add_vect = Vector3.zero;
        AnimToEnd(k);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("OnPointerClick:" + eventData.pointerPressRaycast.gameObject);
        if (add_vect.sqrMagnitude <= 1)
        {
            //Debug.Log("============OnPointerClickOK============");
            UI_Control_ScrollFlow_Item script = eventData.pointerPressRaycast.gameObject.GetComponent<UI_Control_ScrollFlow_Item>();
            if(script!=null)
            {
                float k = script.v;
                k = 0.5f - k;
                AnimToEnd(k);
            }
           
        }
    }


    public float GetApa(float v)
    {
        return ApaCurve.Evaluate(v);
    }
    public float GetPosition(float v)
    {
        return PositionCurve.Evaluate(v) * Width;
    }
    public float GetScale(float v)
    {
        return ScaleCurve.Evaluate(v) * MaxScale;
    }


    private List<UI_Control_ScrollFlow_Item> SortValues = new List<UI_Control_ScrollFlow_Item>();
    private int index = 0;
    public void LateUpdate()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if(Items[i].v>=0.1f &&Items[i].v<=0.9f)
            {
                index=0;
                for (int j = 0; j < SortValues.Count; j++)
                {
                    if(Items[i].sv>=SortValues[j].sv)
                    {
                        index = j + 1;
                    }
                }

                SortValues.Insert(index, Items[i]);
            }
        }

        for (int k = 0; k < SortValues.Count; k++)
        {
            SortValues[k].rect.SetSiblingIndex(k);
        }
        SortValues.Clear();
    }

    public void ToLaster(UI_Control_ScrollFlow_Item item)
    {
        item.v=Items[Items.Count - 1].v + AddValue;
        Items.Remove(item);
        Items.Add(item);
    }

  
    private float AddV = 0, Vk=0,CurrentV=0,Vtotal=0,VT=0;
    private float _v1 = 0, _v2 = 0;
    
    private float start_time = 0, running_time = 0;

    public UI_Control_ScrollFlow_Item Current;



    public void AnimToEnd(float k)
    {
        AddV= k;
        if (AddV > 0) { Vk = 1; }
        else if (AddV < 0) { Vk = -1; }
        else
        {
            return;
        }
        Vtotal = 0;
        _anim = true;

    }

    void Update()
    {
        OnClick();
        if (_anim)
        {
            CurrentV = Time.deltaTime * _anim_speed * Vk;
            VT = Vtotal + CurrentV;
            if (Vk > 0 && VT >= AddV) { _anim = false; CurrentV = AddV - Vtotal; }
            if (Vk < 0 && VT <= AddV) { _anim = false; CurrentV = AddV - Vtotal; }
            //==============
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Drag(CurrentV);
                if(Items[i].v-0.5<0.05f)
                {
                    Current = Items[i];
                }
            }
            Check(CurrentV);
            Vtotal = VT;


            if(!_anim)
            {
                if (MoveEnd != null) { MoveEnd(Current); }
            }
        }
    }
     
}
