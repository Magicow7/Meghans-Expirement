using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSpecifics : MonoBehaviour
{
    public abstract void attack();

    public abstract void mobility();

    protected IEnumerator cooldown(Ref<bool> toSet, float cooldownTime){
        toSet.value = false;
        yield return new WaitForSeconds(cooldownTime);
        toSet.value = true;
    }

}
