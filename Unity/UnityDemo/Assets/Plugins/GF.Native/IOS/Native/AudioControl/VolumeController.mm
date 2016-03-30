//
//  VolumeControler.m
//  Unity-iPhone
//
//  Created by lion on 16/3/30.
//
//

#import <MediaPlayer/MediaPlayer.h>
#import "VolumeController.h"

@implementation VolumeController
UISlider* mVolumeController = nil;
float mCurrentVolume;
bool mIsSilence;
bool mIsMax;


-(void)getMusicVolumeController
{
    MPVolumeView* volume_view = [[MPVolumeView alloc] init];
    volume_view.frame = CGRectMake(-1000, -100, 100, 100);
    if(mVolumeController == nil)
    {
        for (UIView *view in [volume_view subviews]) {
            if ([view.description isEqualToString:@"MPVolumeSlider"]) {
                mVolumeController = (UISlider*)view;
                break;
            }
        }
    }
}

-(void)setMusicSilence
{
    mIsSilence = true;
    mIsMax = false;
    [mVolumeController setValue:0];
}

-(void)cancelMusicSilence
{
    mIsSilence = false;
    [mVolumeController setValue:mCurrentVolume];
}

-(void)setMusicMax
{
    mIsMax = true;
    mIsSilence = false;
    [mVolumeController setValue:1];
}

-(void)cancelMusicMax
{
    mIsMax = false;
    [mVolumeController setValue:mCurrentVolume];
}

-(void)setCurrentMusicVolume:(int) current_muiscvolume
{
    if(mIsSilence ||mIsMax)
    {
        return;
    }
    
    mCurrentVolume =(float)current_muiscvolume/100;
    [mVolumeController setValue:mCurrentVolume];
}

@end

extern "C" void setMusicSilence_ios()
{
    [VolumeController getMusicVolumeController];
    [VolumeController setMusicSilence];
}

extern "C" void cancelMusicSilence_ios()
{
    [VolumeController getMusicVolumeController];
    [VolumeController cancelMusicSilence];
}

extern "C" void setMuiscMax_ios()
{
    [VolumeController getMusicVolumeController];
    [VolumeController setMusicMax];
}

extern "C" void cancelMusicMax_ios()
{
    [VolumeController getMusicVolumeController];
    [VolumeController cancelMusicMax];
}

extern "C" void setCurrentMusicVolum_ios(int current_musicvolume)
{
    [VolumeController getMusicVolumeController];
    [VolumeController setCurrentMusicVolume:current_musicvolume];
}
