using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

interface IContext
{
    public void Initialize();
    public void CreateBuilder();
}
public class Context : MonoBase, IContext
{
    [SerializeField] protected Builder mainBuilder;
    protected Container container;
    public override void Initialize()
    {
        container = new();
        if (mainBuilder == null) CreateBuilder();
        mainBuilder.Build(container);
        container.Initialize();
    }

    public void CreateBuilder()
    {
        mainBuilder = FindObjectOfType<Builder>();
        if(mainBuilder != null) return;
        Debug.LogError("There is no builder in scene. Creating temporary instance.");
        var gObj = new GameObject("TemporaryBuilder", typeof(Builder));
        mainBuilder = gObj.GetComponent<Builder>();
    }
}