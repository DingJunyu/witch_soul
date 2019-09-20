using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class RightClickMenu : MonoBehaviour, IPointerExitHandler {
    private int m_skill = 0;

    public bool pu_outOfMenu = true;

    RectTransform m_plate;
    int m_frameCount = 1;
    const int mc_waitFrame = 5;
    bool m_getNextFrameCount = true;
    void Count() {
        if (!m_getNextFrameCount)
            return;
        m_frameCount++;
        if (m_frameCount == mc_waitFrame)
            m_getNextFrameCount = false;
    }

    GameObject myRealParent;

    const float m_width = 100f;
    const float m_heightPerButton = 40f;
    const float m_nextButtonY = 30f;
    const float m_startY = 60f;
    const float m_defaultHeight = 200f;

    //最大7個ですが、同じ風に追加しても構わない
    public GameObject pu_button1;
    public GameObject pu_button2;
    public GameObject pu_button3;
    public GameObject pu_button4;
    public GameObject pu_button5;
    public GameObject pu_button6;
    public GameObject pu_button7;

    // Start is called before the first frame update
    void Awake() {
        //初期化する時に親を指定する
        //この後の初期化によって、親が変更します。
        //初期化順番が変わる可能性もあるが、このscriptは必ずMovableUIの前に置いてください
        myRealParent = transform.parent.gameObject;
        SetPlateSize();
        SetButtonPos();
    }

    private void CountButtonNum() {
        if (pu_button1 != default) m_skill++;
        if (pu_button2 != default) m_skill++;
        if (pu_button3 != default) m_skill++;
        if (pu_button4 != default) m_skill++;
        if (pu_button5 != default) m_skill++;
        if (pu_button6 != default) m_skill++;
        if (pu_button7 != default) m_skill++;
    }

    //ボタン数に応じて背景の大きさを調整する
    private void SetPlateSize() {
        CountButtonNum();//繋がったボタンの数を統計する
        m_plate = transform.Find("Plate").GetComponent<RectTransform>();
        m_plate.sizeDelta = new Vector2(m_width, m_skill * m_heightPerButton);
    }

    private void SetButtonPos() {
        int counter = 0;
        if (pu_button1 != default) SetThisButton(ref pu_button1, counter++);
        if (pu_button2 != default) SetThisButton(ref pu_button2, counter++);
        if (pu_button3 != default) SetThisButton(ref pu_button3, counter++);
        if (pu_button4 != default) SetThisButton(ref pu_button4, counter++);
        if (pu_button5 != default) SetThisButton(ref pu_button5, counter++);
        if (pu_button6 != default) SetThisButton(ref pu_button6, counter++);
        if (pu_button7 != default) SetThisButton(ref pu_button7, counter++);
    }

    //番号順でボタンを初期化する
    private void SetThisButton(ref GameObject thisButton, int num) {
        thisButton = Instantiate(thisButton, transform);
        if (num != 0)
            thisButton.transform.localPosition = new Vector3(0f,
                m_startY * m_startY / m_defaultHeight - m_nextButtonY * num,
                0f);
        else
            thisButton.transform.localPosition = new Vector3(0f,
                m_startY * m_startY / m_defaultHeight,
                0f);
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnPointerExit(PointerEventData pointData) {
        Destroy(transform.gameObject);
    }

    public void DestoryParent() {
        Destroy(myRealParent);
    }
}
