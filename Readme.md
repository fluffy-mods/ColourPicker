# ColourPicker
This is a small utility plugin for RimWorld mods, providing an effective and easy to use Colour Picker.

![preview](https://i.imgur.com/dqfi7Vm.gif)  
_Note: odd colour banding is a GIF compression artifact._

## How to use
1. Include `0ColourPicker.dll` in your project. Make sure to copy the dll to the assemblies folder.

2. Open `Dialog_ColourPicker`, providing a callback to apply the chosen colour;

```c#
Find.WindowStack.Add( new Dialog_ColourPicker( currentColour, ( newColour ) =>
    {
        // do something with the new colour.
    } ) );
```

3. Lean back, ColourPicker will handle the rest.