using System;
using System.Collections.Generic;

public interface INativeAPI
{
    //-------------------------------------------------------------------------
    void pay(string charge_data);
    void takeNewPhoto(int photo_width, int photo_height, string store_photopath);
    void takeExistPhoto(int photo_width, int photo_height, string store_photopath);
}
