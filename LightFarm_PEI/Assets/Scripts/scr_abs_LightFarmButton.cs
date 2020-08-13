using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This abstract class is for creating our own button event system. Instead of using unitys inspector UI event system.
public abstract class scr_abs_LightFarmButton : MonoBehaviour
{
    [SerializeField] protected Button button;



    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }



    protected abstract void OnClick();


}
