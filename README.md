# GDIM32-Final
## Check-In

### Group Devlog
While we were working on our project, we made the mistake of working on the game at the same time that affected the same things. So this caused a merge conflict for us since as we were trying to pull the changes, a popup was telling us about a merge conflict. From what we learned, we knew that this was a version control issue with Github. We decided to use version control techniques that we learned in class like reverting changes from commits since it seemed the best way to go back to the way our game was before the merge conflicts and we thought that we could just do the work again. So, we decided to revert the changes from the commits that were possibly causing the merge conflict. This solved the issue for us and we just redo the work that we did. 

### Team Member Gianine Ariane Umai
Some of the things that I did for this project so far was that I imported the some of the assets that we used in the game, fix any rendering issues that some of the assets were having, adjusted the camera and player movement. I also made the crush be able to detect how close the player is to him using an NPC parent class and NPCState enums, and when they are close enough to him, a prompt should show above his head telling the player to press "E" to interact with him. And once player press "E", the dialogue box should show up. I adjusted the player movements controls where if the dialogue box is showing, the player is unable to move. I also worked on the lighting effects where there is a pink spot light on the ground around the crush to show that this is a person that the player may talk to. I added point lights to the lamp posts to help add to the environment.

Classes I worked on:
- NPC class
- NPCState enums
- Crush class

Methods I worked on:
- CheckDistance()
- CrushCheck()

Reflection:
The proposal was detailed enough. It gave us a pretty good overall idea of what we should be doing for our project. It gave our team a clear idea of what we wanted our game to look like so this gave us all the same goal to work towards. The break-down was a good starting place for our team to think about what types of things we would need to do to build our game, but it could have been better and there were things that we had to adjust that were different from the break-down that we had.

### Team Member Kai Castilliano


Over the last few weeks, our team has gone through a lot of trial and error and has had a lot of different coding implemented in our game, which has only advanced it into what it is currently. The first thing I did within the creation of the game was create the script folder for the classes such as the Player, Game Controller, Crush, and NPC scripts. Within the player's class, I implemented the 3d movement in its Update() method. Originally, in the early development, the player was able to walk with the WASD keys using GetAxis (“Vertical”) and GetAxis(Horizontal). After out first playtest we found some errors with the movement more particularly the sensitivity of the mouse, the camera placement, and how choppy it looked animation wise (there was only an animation for the player walking forward and not the side) we ultimately decided to tweak the movement code and have it to where the player was only able to move forward and back- reducing some of the bugs. Other than this, in the player's start method on my device i pushed the cursor's lock state code and created a camera member variable that can be assigned which is a camera object that is a child of the parent, this way it created the 3rd person point of view look to the game rather than first person. The cursorlockstate. Keeps the mouse in the center of the game to prevent drift or weird camera angles and in the player's Start() method I added a UI that activates at the start of the game as a visual guide to show the player where they are pointing, which is useful for when they need to pick up objects!

Apart from this, I had also made the crush character interactable via code within the Crush class. The crush’s gameobject has a collider with Is Triggered enabled. And using this collider logic, the crush originally used an OnTriggerEnter and OnTriggerExit method to which the Crush would detect if their collider collided with the player's collider (if input. get tag = “Player”) then it would call up a UI text that tells the player that they can interact with the crush. I had also created an event within the Crush class OnPlayerClick() which is also referenced within the Game controller class in our code and in this event it makes it so that when the player interacts with the crush the event would trigger which would lead to the Crush’s dialogue activating and then when the player walks away it would cause it to deactivate. I had also imported the background music for the game and created a looped audio source game object and added it into the scene. 

Other than this, I do think the breakdown and having an aid to understand what methods or what logic should be placed well served as a great guide for the three of us. Also having a task manager like Trello gave us an understanding of what tasks we had to do and kept us accountable. 


### Team Member Alejandra Perez 

To prepare for check-in, I worked on  both technical and visual parts of the project.

#### Player Animation
I was in charge of implementing the player animations. I found the animation assets, imported them into Unity, and set them up in the Animator Controller. At first, they weren’t working correctly, and I didn’t really know why. My teammate Gianine helped me figure out what was wrong with the transitions so we could fix them.
This was my first time ever working with animations in Unity. I volunteered to do them because I wanted to learn,  it was stressful  but at  the same time fun.

#### Environment & Asset Placement
I was also responsible for finding free assets for the project. Gianine and I imported them together, and then I built the environment by placing terrain and assets/prefabs in specific places. I used one of the images from our prompt document as a reference so the world would match our ideas.
The environment isn’t fully finished yet, but we’ve built the main layout and important elements for the progression of the game.

#### Interactive Flowers & Inventory System
The biggest part of my contribution was creating the interactive flower system and rebuilding the inventory.
I created ScriptableObjects for:

- The blue flower
- The purple flower
- The red flower
- The Teddy

I implemented methods like:
- Pickup()
- DropItem()
- ListItem()

I also created the InventoryManager using the Singleton so the inventory could be accessed globally.
I connected everything to the inventory UI, working with:

- Buttons
- Text
- Images

The flowers can now:
- Be picked up
- Be dropped
- Be picked up again
- Update the inventory UI

This part took the longest and was honestly the most stressful. We had issues where both my teammate’s and my work got deleted accidentally. That was the first time I built the inventory system. After that, I rebuilt it again. Then my computer shut down without saving, so I had to build it a third time.
Even though it was frustrating, rebuilding it multiple times actually helped me understand inventory systems much better. I also fixed issues like duplicate items appearing in the inventory by adjusting how items were added and listed.

Personally, I think the proposal, the breakdown, and the use of Trello are very helpful. The proposal helps me visualize the game environment, the breakdown helps me understand how to structure and connect the game's interaction, and Trello helps me remember my assigned tasks since I tend to forget my responsibilities.



## Final Submission
### Group Devlog


### Team Member Name 1
Put your individual final Devlog here.
### Team Member Name 2
Put your individual final Devlog here.
### Team Member Alejandra Perez

Since the check-in, the tasks I worked on for the final project were the following:

#### Create a new NPC area

Our team planned to have an area where, in this case, a dog that the player can interact with would be located. Because of this, my task was to create that area. This was one of the easiest and fastest tasks to complete. I placed trees, tables, and a small pavilion. I also added colliders, the dog, and a teddy bear object in the dog’s mouth.

#### Friend NPC walk around

This was one of the most difficult tasks I worked on for the project. From my experience, most of it was based on a demo that was shown in class, specifically the demo of the week 7. In this demo there is an example of a duck walking around the terrain, but when it sees the NPC it tries to attack the player while it looks at them.

For our game we needed something similar, but without the NPC chasing the player. I used methods from the demo. First, I used a state machine to indicate when specific animations needed to play and how the NPC should react. These only had two states: “Walking” and “Interacting”.

Other methods I used from the demo were UpdateState(), RunWalkingState(), RunState(), and NewWalkDirection(), among others. These helped the NPC generate a random direction inside a specific area every certain amount of time, and also made the NPC stop walking when it detected the player at a specific distance so the friends NPC would only see the player. It was difficult, but I felt grateful to have an example that I could use for support and refer to when I was confused.

I also had to deal with keeping the Friend NPC inside a specific area. This was the most frustrating part of this task. At first I tried creating an invisible wall where the player could pass but the NPC could not, but for some reason they still kept leaving the area. Because of this I remembered that I could use NavMesh, so I tried creating one only for a specific area, but it still did not work.

Because of this I asked my teammates for help. They were also confused and did not know the reason for the problem. During one class my teammate Geanine went with me to talk to an LA, and after a long time trying to help me he realized that there was a NavMesh covering the entire terrain, which is why the NPC could leave the area. We had no idea where it came from, so we had to move our whole map to the side of this big square NavMesh.

My teammate Genine searched for where it came from and found that The big Navmesh was created when the scene was first created. Thanks to the help we received in class and Genine’s help, my script was finally able to work successfully.

#### Make 3 flowers into a bouquet and when dropped drop 3 flowers

For this task I added a method called FlowBouquet(). This method keeps track of the flowers by color/name. When the count reaches exactly three, those flowers are automatically removed and the bouquet prefab is added instead.

To make it so that when the bouquet is dropped it drops three flowers, I used a vector for spacing and a loop to repeat the Instantiate. Doing this was a new and interesting way for me to use a loop.
I also created scriptable objects for the bouquets and modified the scriptable items so the game could identify which items were bouquets and which were not. This prevents objects from appearing three times when they are dropped.

#### Other small changes/contributions

Personally, the biggest changes I made for the final project were the ones mentioned above. However, I also made some smaller contributions, such as connecting the dog dialogue with the inventory and updating the inventory UI, fixing the bug with the message when the inventory is full, fixing the Friend NPC animations, and making the teddy bear disappear from the dog’s mouth when the player receives it. These were simpler and less stressful tasks.

## Open-Source Assets

- Enviroment Assets:

    - [Anime Girl]( https://assetstore.unity.com/packages/3d/characters/humanoids/casual-1-anime-girl-characters-185076)
    - [Anime Boy](https://assetstore.unity.com/packages/3d/characters/akio-highschool-uniform-217443)
    - [Anime Girl2](https://assetstore.unity.com/packages/3d/characters/aika-highschool-uniform-221860)
    - [Flowers](https://assetstore.unity.com/packages/3d/vegetation/flowers/demo-low-poly-flower-pack-325074)
    - [Grass](https://assetstore.unity.com/packages/3d/vegetation/plants/flowers-grass-plants-neon3d-239575)
    -  [Trees]( https://assetstore.unity.com/packages/3d/vegetation/trees/low-poly-trees-pack-lite-free-stylized-nature-environment-assets-295464)
    - [Terrain texture]( https://assetstore.unity.com/packages/2d/textures-materials/nature/terrain-textures-free-271990)
    - [Park](https://assetstore.unity.com/packages/3d/environments/urban/low-poly-park-pack-created-with-fastmesh-asset-292938)
    - [Pavilion] (https://assetstore.unity.com/packages/3d/props/exterior/pavilion-85680)
    - [Teddy Bear](https://assetstore.unity.com/packages/3d/props/interior/pandazole-home-interior-low-poly-pack-203033)

- Music:
    [ Background Music](https://freemusicarchive.org/music/lowtone-music/just-love-lofi-chill-beat/just-love-1-minute-version-lofi-chill/)
 