## README for 0x09-unity-ar_business_card ##
### A directory within the holbertonschool-unity repo ###
<br>
This is the first Holberton AR project.
<br><br>
The purpose of this project is to create ourselves a buisness card with an AR-identifiable printed marker, either by using the one provided or creating our own.
<br><br>
First a static layout for the business card was created in a Unity Scene called `ARBusinessCard` with my name, job title, and at least four links in text or button form.
<br><br>
Next a target image database in Vuforia's Target Manager had to be set up for the AR marker. This would allow the business card's layout to appear once the device's camera detects it. The layout is anchored to the marker, meaning the transform values had to change depending on the marker's angle, pose, and distance in relation to the device's camera. If not visible, then all elements of the business card would disappear.
<br><br>
Then animations were to be added to the layout. The design and feel wasn't specified, so long as the overall user experience was strong (legible text, large enough buttons to press individually, etc).
<br><br>
Afterward, the links had to be scripted in order to be interactive. This means when the buttons were pressed on the device screen, they had to open the associated link or app. The buttons also had to give some sort of visual/audible feedback when pressed, this could be a button color change or a click sound. The accessibility guidelines had to be kept in mind for the UI/UX decisions as well.
<br><br>
Lastly, the builds of the business card scene had to be made. The `ARBuisnessCard` scene had two builds, one for iOS and another for Android.
