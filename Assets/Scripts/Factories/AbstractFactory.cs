using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFactory<T> where T : IProduct
{
    protected T objectToCreate;

    //----CONSTRUCTOR----
    public AbstractFactory(T objectToCreate)
    {
        this.objectToCreate = objectToCreate;
    }

    //----METHODS----
    public abstract T CreateObject();
}