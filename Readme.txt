Video: 
Github: https://github.com/Bnuey/Narrative-Game-GDW


Part 1: Improvements --------------------------------------------------------------------

-Everything has been textured now
-Several bug fixes
-Added vignette for style
-Added Lens Flares
-Added Particles
-Added Outline Shader

Part 2: Texturing --------------------------------------------------------------------=

Every environment surface, such as the walls and floor for each room, have now been textured
The textures were created:
-Downloading from AmbientCG
-Changing each part of the texture to only be 64x64 pixels
-Removed Anti-aliasing
-Imported them into the game and turned their Tiling scale to 0.2

This makes for interesting looking textures that still match the asthetics. They work really well with the dither shader to give a pixelated feel

Here are the original textures from AmbientCG
	-https://ambientcg.com/view?id=WoodFloor051
	-https://ambientcg.com/view?id=Wallpaper001C
	-https://ambientcg.com/view?id=Carpet012
	-https://ambientcg.com/view?id=Bricks085

Part 3: Visual Effects --------------------------------------------------------------------

-Outline Shader
	The outline actually works differently from the example from class. It uses the same base shader to get the outline effect, but the render settings in the Universal Render Data asset are setup in a way that draws everything first, then draws the outlines, then draws the object on top. This makes the outline look more consistent especially with areas of high detail. You can't potentially see the outline from a face the camera is parallel to. It's hard to explain with just text but basically it looks better espeically with more complex objects.

-Particles
	A Particle System is used that covers the entire scene. It simply creates falling star dust with trails. I felt like this added to the fact that the game takes place in a dream. It gives it a magical feel.

-Lens Flare
	I found out that there is actually a component just for lens flares. You can either use the 'Lens Flare' component or 'Lens Flare (SRP)' depending on if you are using URP or not. Then I just added this component and tweawked the settings to all the lights in the scene.
