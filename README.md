# Workshop Harvest Simulator

This project implements an inventory system in Unity to manage collectible objects and player interactions.

### Objective:
This project aims to develop a basic harvesting game where a character navigates on a flat surface. The player can move the character by clicking on the desired location. The game will also include obstacles on the navigable surface.

## Current Project Status

### Implemented Features

1. **Object Collection:** Players can collect objects when they collide with them in the scene.

2. **Inventory:** Collected objects are added to the player's inventory.

3. **Inventory Activation/Deactivation:** The inventory can be toggled using the Tab key.

### What's Working

- Player movement.
- Obstacle collisions.
- Detection of collision with collectible objects.
- Activation/deactivation of the inventory.

### What's Not Working

- Adding collected objects to the inventory.

## To-Do List

1. **Interaction with Inventory Objects:** When dragging one identical object onto another in the inventory, it should upgrade to a higher-quality object.

2. **Error Handling:** Handle cases where certain object references are null, preventing exceptions.

3. **User Interface Improvements:** Add graphical elements to enhance the visibility and aesthetics of the inventory.

## Project Structure

The project is organized using various Unity scripts:

- **PlayerDropItemFromInventory.cs:** Manages object collection and interactions with the inventory.
- **SlotItemSystem.cs:** Handles the inventory system and associated events.
- **ActivateInventory.cs:** Manages the activation/deactivation of the inventory.
- **DragItem.cs:** Controls the drag-and-drop of objects into the inventory.
- **SciptableHolder.cs:** A component to hold data associated with a collectible object.
- **InventoryEvent.cs:** Defines events for communication between different scripts.
- **ItemData.cs and ItemListData.cs:** ScriptableObjects to define object types and list collectible objects.