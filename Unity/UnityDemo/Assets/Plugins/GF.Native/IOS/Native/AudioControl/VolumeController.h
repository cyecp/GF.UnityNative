//
//  VolumeControler.h
//  Unity-iPhone
//
//  Created by lion on 16/3/30.
//
//

#ifndef VolumeControler_h
#define VolumeControler_h


#endif /* VolumeControler_h */
@interface VolumeController

-(void) getMusicVolumeController;
-(void) setMusicSilence;
-(void) cancelMusicSilence;
-(bool) getIsSilence;
-(void) setMusicMax;
-(void) cancelMusicMax;
-(bool) getIsMaxVolume;
-(void) setCurrentMusicVolume:(int) current_muiscvolume;
-(float) getCurrentMusicVolume;
@end