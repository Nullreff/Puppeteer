# Puppeteer

This is a work in progress, check back later.

A [NeosModLoader](https://github.com/zkxs/NeosModLoader) mod for [Neos VR](https://neos.com/) that allows for creating clones that can be puppeted and controlled by the original.

## Installation

1. Install [NeosModLoader](https://github.com/zkxs/NeosModLoader).
2. Place [Puppeteer.dll]() into your `nml_mods` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\NeosVR\nml_mods` for a default install. You can create it if it's missing, or if you launch the game once with NeosModLoader installed it will create the folder for you.
3. Start the game. If you want to verify that the mod is working you can check your Neos logs.

## Usage

This plugin is controlled using dynamic impulses.
It will only listen for impulses coming from the user running it.

### Impluses

* `<userID>.Puppeteer.Start` `Slot` - Starts the cloning/puppeting process. The slot passed should include a dynamic variable space containing all the variables listed below. If the process has already started this does nothing.
* `<userID>.Puppeteer.Refresh` `Slot` - Performs a deep refresh of everything including source, template and variable changes
* `<userID>.Puppeteer.Stop` `Slot` - Stops the cloning/puppeting process on a slot that `Start` was previously called on.
* `<userID>.Puppeteer.Error` `string` - Called by the plugin when it encounters an internal error, used for debugging

To stop the puppeting process, simply destroy the slot passed in to `<userID>.Puppeteer`

### Variables

* `Source` `Slot` - The slot to clone from 
* `Target` `Slot` - The slot to parent the clone under
* `Template` `Slot` - A slot containing components that will serve as the template for all cloned slots.
* `Include` `string` - What slots and components should be cloned over, see options below
* `Puppet` `string` - What fields should be puppeted by the original object, see options below
* `Live` `bool` - If false the clone will only happen once, if true the system will monitor for added/deleted slots. This does not track any other changes.
* `Frequency` `float` - Live updates will happen every X seconds, if not included updates happen every frame
* `KeepEmptySlots` `bool` - If true keep slots even if they have no components or children

#### Include Options

* `<comma seperate list of component names>` - Copies over only the specified components
* `Puppeteer.MeshRenderers` - Will only clone `MeshRenderers` and `SkinnedMeshRenderer` components
* `Puppeteer.Everything` - Copies everything 

Regardless of options provided, `SimpleAvatarProtection` components will always be copied.

#### Puppet Options

* `Puppeteer.Transform` - Copies over position, rotation and scale
* `Puppeteer.Template` - On every slot looks for a `ReferenceField<Slot>` called `Puppeteer.Source` and writes the source of the current slot to it
