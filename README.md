## Level Scene Setting Guideline

1. Create a new scene
2. Map configuration
   - Map generating
     - if you want to use tilemap to create map, please checkout the [link](https://youtu.be/QkbGr1rAya8)
   - Layer and Tag Setting
     1. Ground
        - Add `Ground` layer to your ground
     2. Water
        - Add `Water` tag and `Water` layer
        - Dash player won't die when colliding with water and standing on water
     3. Trap
        - Add `Trap` tag to your trap
        - all players will die when colliding with traps
3. Add gameobjects from prefabs

   - GameObjects

   1. MainCamera
   2. PlayerController
   3. player
   4. Canvas
      - drag MainCamera to "Render Camera"
   5. respawn

   - Please don't override prefab object

4. Troubleshooting
   1. prevent player to stuck on the edge, please checkout the [link](https://youtu.be/LEUhxe9vUOM)
