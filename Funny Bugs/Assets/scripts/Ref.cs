using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code I found on the internet for passing refrences into iterators
public class Ref<T>
{
    private T backing;
    public T value {get{return backing;} set{backing = value;}}
    public Ref(T reference)
    {
        backing = reference;
    }
}
