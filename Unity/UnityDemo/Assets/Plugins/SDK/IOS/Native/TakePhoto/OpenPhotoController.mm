#import "OpenPhotoController.h"



@implementation OpenPhotoController
@synthesize popoverViewController = _popoverViewController;

-(void)showActionSheet
{
    UIActionSheet *sheet = [[UIActionSheet alloc] initWithTitle:nil
                                                delegate:self
                                                cancelButtonTitle:NSLocalizedString( @"取消", nil )
                                                destructiveButtonTitle:nil
											    otherButtonTitles:NSLocalizedString( @"拍照", nil ), NSLocalizedString( @"相册", nil ), nil];
	
	if( UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad )
		[sheet showFromRect:CGRectMake( 0, 0, 128, 128 ) inView:UnityGetGLViewController().view animated:YES];
	else
		[sheet showInView:UnityGetGLViewController().view];
	
	[sheet release];
    
}
- (void)actionSheet:(UIActionSheet*)actionSheet clickedButtonAtIndex:(NSInteger)buttonIndex
{
	if( buttonIndex == 0 )
	{
		[self showPicker:UIImagePickerControllerSourceTypeCamera];
	}
	else if( buttonIndex == 1 )
	{
		[self showPicker:UIImagePickerControllerSourceTypePhotoLibrary];
	}
	else // Cancelled
	{
	
	}
}

- (void)showPicker:(UIImagePickerControllerSourceType)type
{
	UIImagePickerController *picker = [[[UIImagePickerController alloc] init] autorelease];//[[[UIImagePickerController alloc] init] autorelease];
	picker.delegate = self;
	picker.sourceType = type;
	picker.allowsEditing = YES;
	
	// We need to display this in a popover on iPad
	if( UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad )
	{
		Class popoverClass = NSClassFromString( @"UIPopoverController" );
		if( !popoverClass )
			return;
        
		_popoverViewController = [[popoverClass alloc] initWithContentViewController:picker];
		[_popoverViewController setDelegate:self];
		//picker.modalInPopover = YES;
		
		// Display the popover
		[_popoverViewController presentPopoverFromRect:CGRectMake( 0, 0, 128, 128 )
												inView:UnityGetGLViewController().view
							  permittedArrowDirections:UIPopoverArrowDirectionAny
											  animated:YES];
	}
	else
	{
		// wrap and show the modal
        UIViewController *vc = UnityGetGLViewController();
		[vc presentModalViewController:picker animated:YES];
	}
}
- (void)popoverControllerDidDismissPopover:(UIPopoverController*)popoverController
{
	self.popoverViewController = nil;
}

- (void)imagePickerController:(UIImagePickerController*)picker didFinishPickingMediaWithInfo:(NSDictionary*)info
{
	// Grab the image and write it to disk
	UIImage *image;
	UIImage *image2;
    //	if( _pickerAllowsEditing )
    image = [info objectForKey:UIImagePickerControllerEditedImage];
    //        else
    //            image = [info objectForKey:UIImagePickerControllerOriginalImage];
    
    NSLog( @"picker got image with orientation: %li", (long)image.imageOrientation );
    UIGraphicsBeginImageContext(CGSizeMake(128,128));
    [image drawInRect:CGRectMake(0, 0, 128, 128)];
    image2 = UIGraphicsGetImageFromCurrentImageContext();
    UIGraphicsEndImageContext();
    
    // 得到了image，然后用你的函数传回u3d
    NSData *imgData;
    if(UIImagePNGRepresentation(image2) == nil)
    {
        imgData= UIImageJPEGRepresentation(image2, .6);
    }
    else
    {
         imgData= UIImagePNGRepresentation(image2);
    }
    
    NSString *_encodeImageStr = [imgData base64Encoding];
    
    UnitySendMessage( "NativeAPIMsgReceiver", "sendPicture", _encodeImageStr.UTF8String);
    
	// Dimiss the pickerController
	[self dismissWrappedController];
}
- (void)imagePickerControllerDidCancel:(UIImagePickerController*)picker
{
	// dismiss the wrapper, unpause and notifiy Unity what happened
	[self dismissWrappedController];
}

- (void)dismissWrappedController
{
	UIViewController *vc = UnityGetGLViewController();
	
	// No view controller? Get out of here.
	if( !vc )
		return;
	
	// dismiss the view controller
	[vc dismissModalViewControllerAnimated:YES];
    
	// remove the wrapper view controller
	[self performSelector:@selector(removeAndReleaseViewControllerWrapper) withObject:nil afterDelay:1.0];
}

- (void)removeAndReleaseViewControllerWrapper
{
	// iPad might have a popover
	if( UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad && _popoverViewController )
	{
		[_popoverViewController dismissPopoverAnimated:YES];
		self.popoverViewController = nil;
	}
}
@end

extern "C" void openPhoto()//相册
{
    OpenPhotoController * app = [[OpenPhotoController alloc] init];
	// No need to give a choice for devices with no camera
	if( ![UIImagePickerController isSourceTypeAvailable:UIImagePickerControllerSourceTypeCamera] )
	{
		[app showPicker:UIImagePickerControllerSourceTypeSavedPhotosAlbum];
		return;
	}
	[app showActionSheet];
	
}