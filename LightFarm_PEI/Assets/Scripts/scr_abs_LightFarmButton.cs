using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
