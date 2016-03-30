using System;
using System.Collections.Generic;

public interface INativeAPI
{
    //-------------------------------------------------------------------------
    void pay(string charge_data);
    void takeNewPhoto(int photo_width, int photo_height, string photo_name);
    void takeExistPhoto(int photo_width, int photo_height, string photo_name);
    void setMusicSilence();
    void cancelMusicSilence();
    void setMusicMax();
    void cancelMusicMax();
    void setCurrentMusicVolume(int current_muiscvolume);
}
