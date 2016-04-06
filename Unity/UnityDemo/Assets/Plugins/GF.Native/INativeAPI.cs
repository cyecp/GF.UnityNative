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
    int getIsSilence();//0false 1true
    void setMusicMax();
    void cancelMusicMax();
    int getIsMaxVolume();//0false 1true
    void setCurrentMusicVolume(float current_muiscvolume);
    float getCurrentMusicVolume();
}
