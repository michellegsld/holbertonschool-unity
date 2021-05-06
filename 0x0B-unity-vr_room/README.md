## README for 0x0A-unity-vr_room ##
### A directory within the holbertonschool-unity repo ###
<br>
This is the second Holberton project with VR capabilities.
<br><br>
The purpose of this project is to create an Escape Room in VR. This project is meant to be experienced either by sitting or standing. The purpose of the Escape Room is to provide the player with mandatory tasks unveiled through simple exploration.
<br><br>
First, a Unity scene was downloaded and imported along with assets and the target VR SDK. In this case, this was `SteamVR` with mainly the `Valve Index` in mind. The Camera / Player object was placed with at least one controller in the scene.
<br><br>
Then the "teleportation" method of movement was implemented so that the user could use the controller to indicate where they want to move and move there on a button press. This was done while following these guidelines:
<ul><li>The user should not be able to teleport outside the boundaries of the room or into other objects (passing through colliders)</li><li>The user should not be able to teleport through the closed door</li><li>The user should be given visual feedback that indicated where they're teleporting to</li><li>Implement a method of teleportation that reduces the chances of motion sickness and accounts for different play area sizes</li></ul>
<br>
Next, interactions were created that allows an object to be picked up or interacted with by the controller(s). This interaction was created with `SteamVR` and the `Valve Index` in mind while also thinking about keeping a smooth and intuitive experience. This was done while following these guidelines:
<ul><li>Objects should not be able to move outside the boundaries of the room or into other objects (passing through colliders)</li><li>The user should recieve visual feedback to indicate if an object can be interacted with (highlight, label, change in object's appearance, etc)</li><li>Objects should react accordingly to actions such as being dropped or thrown (affected by physics accurately)</li></ul>
<br>
Then an interaction was scripted in the scene so that the door opens with an animation when the user interacts with it. The door's animation occurs when it opens, and after it plays the user is then able to pass through the doorway. The boundaries of the rooms are unable to be moved, edited, or changed in any way. New GameObjects were allowed to be added, which means there could be more props, 3D models, UI, animations, etc but anything already existing could not be removed. Materials and textures were also allowed to be added or edited.
<br><br>
After that, another interaction was scripted in the scene so a projector in the center of the second room would turn on once the user interacted with it. This animation was already included as a prefab. Just like before, the boundaries of the rooms weren't able to be changed in any way, new GameObjects could be added but no existing ones were able to be removed, and materials/textures could be added or edited.
<br><br>
Lastly, the builds of this VR Escape Room had to be made. There was only one scene in the build for the targeted device.
<br><br>
Afterward, there were advanced tasks available that would add even more things to the scene. First, a scene interaction had to be scripted so that the user would have to interact with at least two objects before the glass door would open. Secondly, another scene interaction had to be scripted so the user would have to interact with at least four objects before the projector in the center of the second room would turn on. This means they can couldn't open the door or turn on the projector until they interact with these objects. The interactions had have some sort of logical reasoning and not be completely random.
<br><br><br>
Credit:
<br><br>
The Unity Scene and Assets Used:
Download Link: https://s3.amazonaws.com/intranet-projects-files/holbertonschool-cs-unity/assets_042019.zip
