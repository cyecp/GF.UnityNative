﻿using UnityEngine;
using System.Collections;

public interface INativeTakePhoto
{
    //-------------------------------------------------------------------------    
    void takeNewPhoto(int photo_width, int photo_height, string photo_name);
    void takeExistPhoto(int photo_width, int photo_height, string photo_name);
}
