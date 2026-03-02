# GDIM32-Final
## Check-In

### Group Devlog
While we were working on our project, we made the mistake of working on the game at the same time that affected the same things. So this caused a merge conflict for us since as we were trying to pull the changes, a popup was telling us about a merge conflict. From what we learned, we knew that this was a version control issue with Github. We decided to use version control techniques that we learned in class like reverting changes from commits since it seemed the best way to go back to the way our game was before the merge conflicts and we thought that we could just do the work again. So, we decided to revert the changes from the commits that were possibly causing the merge conflict. This solved the issue for us and we just redo the work that we did. 

### Team Member Gianine Ariane Umai
Some of the things that I did for this project so far was that I imported the some of the assets that we used in the game, fix any rendering issues that some of the assets were having, adjusted the camera and player movement. I also made the crush be able to detect how close the player is to him using an NPC parent class and NPCState enums, and when they are close enough to him, a prompt should show above his head telling the player to press "E" to interact with him. And once player's press "E", the dialogue box should show up. I adjusted the player movements controls where if the dialogue box is showing, the player is unable to move. I also working on the lighting effects where there is a pink spot light on the ground around the crush to show that this is a person that the player may talk to. I added point lights to the lamp posts to help add to the environment.

### Team Member Name 2
Put your individual check-in Devlog here.

### Team Member Alejandra Perez Name 3

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
### Team Member Name 3
Put your individual final Devlog here.

## Open-Source Assets

- Enviroment Assets:

    - Anime Girl: https://assetstore.unity.com/packages/3d/characters/humanoids/casual-1-anime-girl-characters-185076
    - Anime Boy: https://assetstore.unity.com/packages/3d/characters/akio-highschool-uniform-217443
    - Anime Girl2: https://assetstore.unity.com/packages/3d/characters/aika-highschool-uniform-221860
    - Flowers: https://assetstore.unity.com/packages/3d/vegetation/flowers/demo-low-poly-flower-pack-325074
    - Grass: https://assetstore.unity.com/packages/3d/vegetation/plants/flowers-grass-plants-neon3d-239575
    - Trees: https://assetstore.unity.com/packages/3d/vegetation/trees low-poly-trees-pack-lite-free-stylized-nature-environment-assets-295464
    - Terrain texture: https://assetstore.unity.com/packages/2d/textures-materials/nature/terrain-textures-free-271990
    - Park: https://assetstore.unity.com/packages/3d/environments/urban/low-poly-park-pack-created-with-fastmesh-asset-292938
    - Pavilion: https://assetstore.unity.com/packages/3d/props/exterior/pavilion-85680
    - Teddy Bear: https://assetstore.unity.com/packages/3d/props/interior/pandazole-home-interior-low-poly-pack-203033

- Music:
    - https://freemusicarchive.org/music/lowtone-music/just-love-lofi-chill-beat/just-love-1-minute-version-lofi-chill/
    - https://pixabay.com/sound-effects/film-special-effects-walk-on-grass-2-291985/