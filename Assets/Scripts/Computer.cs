﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour{
     public bool repaired;                      //se il monitor è stato fixado
     public void setRepaired(bool repaired){
          this.repaired = repaired;
          // Alert tile manager
     }


}
