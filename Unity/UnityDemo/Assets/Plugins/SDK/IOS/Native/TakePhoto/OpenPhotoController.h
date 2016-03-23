@interface OpenPhotoController : NSObject<UIApplicationDelegate,UIImagePickerControllerDelegate, UIActionSheetDelegate,UINavigationControllerDelegate>
{
    
	UIView*				_rootView;
	UIViewController*	_rootController;
@private
	id _popoverViewController;
}
@property (nonatomic, retain) id popoverViewController;
@end
