## README for 0x0A-unity-360_video_tour ##
### A directory within the holbertonschool-unity repo ###
<br>
This is the first Holberton project with VR capabilities.
<br><br>
The purpose of this project is to create a 360 video VR tour of the SF Holberton Campus that allows for user navigation and text information.
<br><br>
First a scene called `360VideoTour` was created. In this scene a Sphere object is created for each room. The 360 video, which plays automatically and loops, is also wrapped along the inside of each sphere with the VR camera in the center.
<br><br>
Next, buttons were added to actually allow the user to navigate between the different rooms. A behavior was created so when the user interacts with the button either with the controller or user gaze, it will take them to where ever that button points to.
<br><br>
Then transitions between rooms were added so that the current room would fade to black with the destination room fading in. This allows to ease the user into the scene change without causing disorientation or discomfort.
<br><br>
Afterward another button was created that, when interacted with, would activate an informational text box. This info box had to fit within the camera's field of view and have a legible text size. The button should then close the text box if interacted with again.
<br><br>
Lastly, after adding audio, the builds of this 360 Video had to be made. The `360VideoTour` scene had one build for the targeted device.
<br><br><br>
Credit:
<br><br>
Audio:
<br>
Tech Live by Kevin MacLeod
Link: https://incompetech.filmmusic.io/song/4463-tech-live
License: http://creativecommons.org/licenses/by/4.0/
