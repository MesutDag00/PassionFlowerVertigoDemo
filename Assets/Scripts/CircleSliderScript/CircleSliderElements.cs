using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CircleSliderElements : MonoBehaviour
{
    public List<ZoneManger> Childs;
    public Transform[] TargetObject;

    public GameObject SaveZone;
    public GameObject NotZone;
    public GameObject SpawnObject;

    private int SpawnNumber = 6;

    private void Start()
    {
        ChildAdds();
        for (int i = 0; i < transform.childCount - 1; i++)
            if (i != 0)
                Childs[i].ObjectMove(TargetObject);
    }

    public void ChildAdds()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
            Childs.Add(transform.GetChild(i).GetComponent<ZoneManger>());
    }

    public void ClearButton() => ChildAdds();

    public void NewSliderChidlObject()
    {
        SpawnNumber++;
        GameObject obj = Instantiate(SpawnNumber % 5 == 0 ? SaveZone : NotZone, SpawnObject.transform.position,
            SpawnObject.transform.rotation);
        obj.transform.SetParent(this.transform);
        obj.transform.SetSiblingIndex(Childs.Count);
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.transform.GetChild(0).GetComponent<TMP_Text>().text = SpawnNumber.ToString();
        obj.GetComponent<ZoneManger>().TargetNumber = -1;
        Childs.Add(obj.GetComponent<ZoneManger>());
    }

    public void ClickTextButton()
    {
        //Buraya el Atılıcak
        for (int i = 0; i < Childs.Count; i++)
        {
            Childs[i].TargetNumber++;
            if (Childs[i].TargetNumber == 4) ChildSet(Childs[i].gameObject, 1.3f);
            else if (Childs[i].TargetNumber == 5) ChildSet(Childs[i].gameObject, 1);

            if (Childs[i].TargetNumber < 10)
                Childs[i].ObjectMove(TargetObject);

            // ClearButton();
        }

        NewSliderChidlObject();
    }

    private void ChildSet(GameObject childObject, float endValue) =>
        childObject.transform.DOScale(new Vector3(1, endValue, 1), 0.2f).SetEase(Ease.Flash);
}