# AddressBook.Xamarin
## Overview
This repository contains **Address Book** application for Xamarin that shows design & coding practices followed by **[Differenz System](http://www.differenzsystem.com/)**. 

The app does the following:
1. **Login:** 
    - User can login via facebook or email/password. 
2. **Home:** 
    - It will list all the saved contacts. 
    - It has the option to add a new contact on the top right.
    - Contact can be deleted by swiping card to left and clicking on trash icon.
    - User can edit contact by tapping on contact.
3. **Create new contact:** 
    - User can add a new contact to his address book by filling details here.
4. **Dark/Light Mode:** 
    - App supports Light & Dark mode, user can change mode by going into device dark mode settings.
5. **Localization:**
    - App is designed to extend support for multiple languages. Currently we have added support for english language.
    
## Pre-requisites
- iOS device or emulator running iOS 7 or above
- Android device or emulator running API 21 (5.0 - Lollipop) or above
- [Android SDK 27](https://developer.android.com/about/versions/oreo/android-8.0-migration.html#ptb)
- [Xcode 9](https://developer.apple.com/library/content/releasenotes/DeveloperTools/RN-Xcode/Chapters/Introduction.html#//apple_ref/doc/uid/TP40001051-CH1-SW936)
- [Visual Studio](https://www.visualstudio.com/vs/features/mobile-app-development/#downloadvs)
## Getting Started
1. [Install Visual Studio](https://www.visualstudio.com/vs/features/mobile-app-development/#downloadvs)
2. Clone this sample repository
3. Open the sample project into Visual Studio
	- File -> Open
	- Browse to <path_to_project>/DifferenzXamarinDemo.sln
	- Click "Open"
4. Select project to run (android or ios) from top left after toolbar. Click on :arrow_forward: button

## Key Tools & Technologies
- **Database:** [sqlite-net-pcl](https://www.nuget.org/packages/sqlite-net-pcl/1.7.335) (1.7.335)
- **Authentication:** [Xamarin.Auth](https://www.nuget.org/packages/Xamarin.Auth/1.7.0) (1.7.0)
- **API/Service calls:** HttpClient
- **IDE:** [Visual Studio Community for MAC](https://www.visualstudio.com/vs/visual-studio-mac/) (8.7.8)
- **Framework:** [Prism](https://prismlibrary.com/docs/xamarin-forms/Getting-Started.html)
- **Localization:** [Plugin.Multilingual](https://www.nuget.org/packages/Plugin.Multilingual/1.0.2) (1.0.2)

- **Others:** [Xamarin.Forms](https://www.nuget.org/packages/Xamarin.Forms/) (4.8.0.1560), [Nuget](https://www.nuget.org/) (5.7.0.6702), [.NET Standard](https://www.microsoft.com/net/learn/get-started/macos) (2.0), [Xamarin.Android](https://developer.xamarin.com/api/root/MonoAndroid-lib/) (11.0.2.0), Xamarin.iOS (14.0.0.0)

## Screenshots
### Android
<img src="https://github.com/differenz-system/AddressBook.Xamarin/blob/master/ScreenShots/Android/login.png" width="280"> <img src="https://github.com/differenz-system/AddressBook.Xamarin/blob/master/ScreenShots/Android/list.png" width="280"> <img src="https://github.com/differenz-system/AddressBook.Xamarin/blob/master/ScreenShots/Android/detail.png" width="280">  

### iOS
<img src="https://github.com/differenz-system/AddressBook.Xamarin/blob/master/ScreenShots/iOS/login.png" width="280"> <img src="https://github.com/differenz-system/AddressBook.Xamarin/blob/master/ScreenShots/iOS/list.png" width="280"> <img src="https://github.com/differenz-system/AddressBook.Xamarin/blob/master/ScreenShots/iOS/detail.png" width="280">

## Support
If you've found an error in this sample, please [report an issue](https://github.com/differenz-system/AddressBook.Xamarin/issues/new). You can also send your feedback and suggestions at info@differenzsystem.com

Happy coding!
